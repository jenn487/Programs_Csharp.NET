using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace AppTaxis.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxiController : ControllerBase
    {
        private readonly ILogger<TaxiController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public TaxiController(ILogger<TaxiController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ??
                "Server=localhost;Database=AppTaxi;Trusted_Connection=true;TrustServerCertificate=true;";
        }

        [HttpGet(Name = "GetTaxis")]
        public async Task<ActionResult<IEnumerable<TaxiDto>>> Get()
        {
            try
            {
                var taxis = new List<TaxiDto>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT Id, Placa FROM Taxi ORDER BY Placa", connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            taxis.Add(new TaxiDto
                            {
                                Id = reader.GetInt32("Id"),
                                Placa = reader.GetString("Placa"),
                                Estado = GetEstadoTaxi(reader.GetInt32("Id"))
                            });
                        }
                    }
                }

                _logger.LogInformation($"Se obtuvieron {taxis.Count} taxis");
                return Ok(taxis);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de taxis");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id}", Name = "GetTaxiById")]
        public async Task<ActionResult<TaxiDto>> GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT Id, Placa FROM Taxi WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var taxi = new TaxiDto
                            {
                                Id = reader.GetInt32("Id"),
                                Placa = reader.GetString("Placa"),
                                Estado = GetEstadoTaxi(reader.GetInt32("Id"))
                            };

                            _logger.LogInformation($"Taxi encontrado: {taxi.Placa}");
                            return Ok(taxi);
                        }
                    }
                }

                _logger.LogWarning($"Taxi con ID {id} no encontrado");
                return NotFound($"Taxi con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el taxi con ID {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost(Name = "CreateTaxi")]
        public async Task<ActionResult<TaxiDto>> Post([FromBody] CreateTaxiDto createTaxiDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Datos inválidos para crear taxi: {PlateAttempt}", createTaxiDto?.Placa);
                return BadRequest(ModelState);
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("INSERT INTO Taxi (Placa) OUTPUT INSERTED.Id VALUES (@Placa)", connection);
                    command.Parameters.AddWithValue("@Placa", createTaxiDto.Placa);

                    var newId = (int)await command.ExecuteScalarAsync();
                    var taxi = new TaxiDto
                    {
                        Id = newId,
                        Placa = createTaxiDto.Placa,
                        Estado = "Disponible"
                    };

                    _logger.LogInformation($"Taxi creado exitosamente: ID {newId}, Placa {createTaxiDto.Placa}");
                    return CreatedAtRoute("GetTaxiById", new { id = newId }, taxi);
                }
            }
            catch (SqlException ex) when (ex.Number == 2627) // Unique constraint violation
            {
                _logger.LogWarning($"Intento de crear taxi con placa duplicada: {createTaxiDto.Placa}");
                return BadRequest($"Ya existe un taxi con la placa {createTaxiDto.Placa}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear taxi con placa {createTaxiDto.Placa}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id}", Name = "UpdateTaxi")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTaxiDto updateTaxiDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Datos inválidos para actualizar taxi ID {id}");
                return BadRequest(ModelState);
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("UPDATE Taxi SET Placa = @Placa WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Placa", updateTaxiDto.Placa);
                    command.Parameters.AddWithValue("@Id", id);

                    var rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        _logger.LogWarning($"Taxi con ID {id} no encontrado para actualizar");
                        return NotFound($"Taxi con ID {id} no encontrado");
                    }

                    _logger.LogInformation($"Taxi ID {id} actualizado con placa {updateTaxiDto.Placa}");
                    return NoContent();
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                _logger.LogWarning($"Intento de actualizar taxi con placa duplicada: {updateTaxiDto.Placa}");
                return BadRequest($"Ya existe un taxi con la placa {updateTaxiDto.Placa}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar taxi ID {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id}", Name = "DeleteTaxi")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Verificar si el taxi tiene viajes asociados
                    var checkCommand = new SqlCommand("SELECT COUNT(*) FROM Viaje WHERE IdTaxi = @Id", connection);
                    checkCommand.Parameters.AddWithValue("@Id", id);
                    var viajesCount = (int)await checkCommand.ExecuteScalarAsync();

                    if (viajesCount > 0)
                    {
                        _logger.LogWarning($"Intento de eliminar taxi ID {id} con {viajesCount} viajes asociados");
                        return BadRequest($"No se puede eliminar el taxi porque tiene {viajesCount} viaje(s) asociado(s)");
                    }

                    var command = new SqlCommand("DELETE FROM Taxi WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    var rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        _logger.LogWarning($"Taxi con ID {id} no encontrado para eliminar");
                        return NotFound($"Taxi con ID {id} no encontrado");
                    }

                    _logger.LogInformation($"Taxi ID {id} eliminado exitosamente");
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar taxi ID {id}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("disponibles", Name = "GetTaxisDisponibles")]
        public async Task<ActionResult<IEnumerable<TaxiDto>>> GetDisponibles()
        {
            try
            {
                var taxisDisponibles = new List<TaxiDto>();

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(@"
                        SELECT t.Id, t.Placa 
                        FROM Taxi t 
                        WHERE t.Id NOT IN (
                            SELECT IdTaxi FROM Viaje 
                            WHERE FechaFin IS NULL
                        )
                        ORDER BY t.Placa", connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            taxisDisponibles.Add(new TaxiDto
                            {
                                Id = reader.GetInt32("Id"),
                                Placa = reader.GetString("Placa"),
                                Estado = "Disponible"
                            });
                        }
                    }
                }

                _logger.LogInformation($"Se encontraron {taxisDisponibles.Count} taxis disponibles");
                return Ok(taxisDisponibles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener taxis disponibles");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        private string GetEstadoTaxi(int taxiId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT COUNT(*) FROM Viaje WHERE IdTaxi = @Id AND FechaFin IS NULL", connection);
                    command.Parameters.AddWithValue("@Id", taxiId);
                    var viajesActivos = (int)command.ExecuteScalar();

                    return viajesActivos > 0 ? "En Viaje" : "Disponible";
                }
            }
            catch
            {
                return "Desconocido";
            }
        }
    }

    // DTOs
    public class TaxiDto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

    public class CreateTaxiDto
    {
        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "La placa debe tener entre 3 y 10 caracteres")]
        [RegularExpression(@"^[A-Z]{3}-\d{3}$", ErrorMessage = "La placa debe tener formato ABC-123")]
        public string Placa { get; set; } = string.Empty;
    }

    public class UpdateTaxiDto
    {
        [Required(ErrorMessage = "La placa es obligatoria")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "La placa debe tener entre 3 y 10 caracteres")]
        [RegularExpression(@"^[A-Z]{3}-\d{3}$", ErrorMessage = "La placa debe tener formato ABC-123")]
        public string Placa { get; set; } = string.Empty;
    }
}