-- Módulo 2, Crear procedimientos almacenados (Insert, Update y Delete) de cada una de las tablas.

-- TABLA TAXI

-- 1. Procedimiento para insertar taxi
CREATE PROCEDURE sp_InsertTaxi 
-- No incluir Id en INSERT si es IDENTITY, ya que se genera automáticamente.
@Placa nvarchar(10)
AS
BEGIN
INSERT INTO Taxi (Placa) VALUES (@Placa)
END;

--2. Procedimiento para editar taxi
CREATE PROCEDURE sp_UpdateTaxi
@Id int,
@Placa nvarchar(10)
AS
BEGIN
UPDATE Taxi
SET Placa = @Placa -- el orden siempre es columna = valor
WHERE Id = @Id;
END;

--3. Procedimiento para eliminar taxi
CREATE PROCEDURE sp_DeleteTaxi 
@Id int
AS
BEGIN
DELETE FROM Taxi WHERE Id = @Id
END;


--TABLA USUARIO

-- 1. Procedimiento para insertar usuario
CREATE PROCEDURE sp_InsertUsuario 
@Documento NVARCHAR(20),
@Nombre NVARCHAR(50),
@Apellido NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Usuario (Documento, Nombre, Apellido)
        VALUES (@Documento, @Nombre, @Apellido);
    END TRY
    BEGIN CATCH
        PRINT 'Error al insertar usuario: ' + ERROR_MESSAGE();
    END CATCH
END;

--2. Procedimiento para actualizar Usuarios
CREATE PROCEDURE sp_UpdateUsuario 
@Id int,
@Documento nvarchar(20),
@Nombre nvarchar(50),
@Apellido nvarchar(50)
AS
BEGIN
UPDATE Usuario
SET
Documento = @Documento,
Nombre = @Nombre,
Apellido = @Apellido
WHERE Id = @Id;
END;

--3 Procedimiento para eliminar usuario
CREATE PROCEDURE sp_DeleteUsuario
@Id int
AS
BEGIN
DELETE FROM Usuario WHERE Id = @Id;
END;

-- TABLA VIAJE

--1. Procedimiento para insertar viajes
CREATE PROCEDURE sp_InsertViaje
@FechaInicio DATETIME,
@FechaFin DATETIME NULL,
@Desde NVARCHAR(100),
@Hasta NVARCHAR(100),
@Calificacion CHAR(1),
@IdTaxi INT,
@IdUsuario INT
AS
BEGIN
    BEGIN TRY
        -- Validar que el Taxi y el Usuario existen antes de insertar
        IF EXISTS (SELECT 1 FROM Taxi WHERE Id = @IdTaxi) 
        AND EXISTS (SELECT 1 FROM Usuario WHERE Id = @IdUsuario)
        BEGIN
            INSERT INTO Viaje (FechaInicio, FechaFin, Desde, Hasta, Calificacion, IdTaxi, IdUsuario)
            VALUES (@FechaInicio, @FechaFin, @Desde, @Hasta, @Calificacion, @IdTaxi, @IdUsuario);
        END
        ELSE
        BEGIN
            PRINT 'Error: El IdTaxi o IdUsuario no existe.';
        END
    END TRY
    BEGIN CATCH
        PRINT 'Error al insertar viaje: ' + ERROR_MESSAGE();
    END CATCH
END;

--2. Procedimiento para editar viajes
CREATE PROCEDURE sp_UpdateViaje
@Id INT,
@FechaInicio DATETIME,
@FechaFin DATETIME NULL,
@Desde NVARCHAR(100),
@Hasta NVARCHAR(100),
@Calificacion CHAR(1),
@IdTaxi INT,
@IdUsuario INT
AS
BEGIN
UPDATE Viaje
SET 
FechaInicio = @FechaInicio,
FechaFin = @FechaFin,
Desde = @Desde,
Hasta = @Hasta,
Calificacion = @Calificacion,
IdTaxi = @IdTaxi,
IdUsuario = @IdUsuario
WHERE Id = @Id;
END;

--3. Procedimiento para eliminar viaje
CREATE PROCEDURE sp_DeleteViaje
@Id INT
AS
BEGIN
    BEGIN TRY
        -- Verificar si el viaje existe antes de eliminar
        IF EXISTS (SELECT 1 FROM Viaje WHERE Id = @Id)
        BEGIN
            DELETE FROM Viaje WHERE Id = @Id;
        END
        ELSE
        BEGIN
            PRINT 'Error: El viaje con el Id especificado no existe.';
        END
    END TRY
    BEGIN CATCH
        PRINT 'Error al eliminar viaje: ' + ERROR_MESSAGE();
    END CATCH
END;


-- TABLA DETALLEVIAJE

--1. Procedimiento para insertar detalle de viaje
CREATE PROCEDURE sp_InsertDetalleViaje
@Fecha datetime,
@Latitude decimal(9,6),
@Longitude decimal(9,6),
@IdViaje int
AS
BEGIN
INSERT INTO DetalleViaje(Fecha, Latitude, Longitude, IdViaje) 
VALUES (@Fecha, @Latitude, @Longitude, @IdViaje)
END;

--2. Procedimiento para editar detalle de viaje
CREATE PROCEDURE sp_UpdateDetalleViaje
@Id int,
@Fecha datetime,
@Latitude decimal(9,6),
@Longitude decimal(9,6),
@IdViaje int
AS
BEGIN
UPDATE DetalleViaje
SET 
Fecha = @Fecha, 
Latitude = @Latitude, 
Longitude = @Longitude, 
IdViaje = @IdViaje
WHERE Id = @Id;
END;

--3. Procedimiento para eliminar DetalleViaje.
CREATE PROCEDURE sp_DeleteDetalleViaje
@Id int
AS
BEGIN
DELETE FROM DetalleViaje WHERE Id = @Id
END;


-- TABLA GRUPO USUARIOS

--1. Procedimiento para insertar GRUPOUSUARIOS
CREATE PROCEDURE sp_InsertGrupoUsuarios
AS
BEGIN
    BEGIN TRY
        INSERT INTO GrupoUsuarios DEFAULT VALUES;
    END TRY
    BEGIN CATCH
        PRINT 'Error al insertar GrupoUsuarios: ' + ERROR_MESSAGE();
    END CATCH
END;

--2. Procedimiento para editar GRUPOUSUARIOS
/*
Dado que Id es único y no hay más columnas en esta tabla, 
no es necesario tener un procedimiento de actualizar, 
ya que no hay valores que modificar
*/
--3. Procedimiento para eliminar GRUPOUSUARIOS.
CREATE PROCEDURE sp_DeleteGrupoUsuarios
@Id INT
AS
BEGIN
    BEGIN TRY
        -- Verificar que el grupo de usuarios exista antes de eliminar
        IF EXISTS (SELECT 1 FROM GrupoUsuarios WHERE Id = @Id)
        BEGIN
            DELETE FROM GrupoUsuarios WHERE Id = @Id;
        END
        ELSE
        BEGIN
            PRINT 'Error: El GrupoUsuarios con el Id especificado no existe.';
        END
    END TRY
    BEGIN CATCH
        PRINT 'Error al eliminar GrupoUsuarios: ' + ERROR_MESSAGE();
    END CATCH
END;


-- TABLA GRUPOUSUARIOSDETALLES

--1. Procedimiento para insertar grupo de usuario detalle
CREATE PROCEDURE sp_InsertGrupoUsuariosDetalle
@IdGrupoUsuarios INT,
@IdUsuario INT
AS
BEGIN
    BEGIN TRY
        -- Validar que los valores existen en las tablas relacionadas
        IF EXISTS (SELECT 1 FROM GrupoUsuarios WHERE Id = @IdGrupoUsuarios)
        AND EXISTS (SELECT 1 FROM Usuario WHERE Id = @IdUsuario)
        BEGIN
            INSERT INTO GrupoUsuariosDetalle (IdGrupoUsuarios, IdUsuario)
            VALUES (@IdGrupoUsuarios, @IdUsuario);
        END
        ELSE
        BEGIN
            PRINT 'Error: El IdGrupoUsuarios o el IdUsuario no existe.';
        END
    END TRY
    BEGIN CATCH
        PRINT 'Error al insertar en GrupoUsuariosDetalle: ' + ERROR_MESSAGE();
    END CATCH
END;

--2. Procedimiento para editar grupo de usuario detalle
CREATE PROCEDURE sp_UpdateGrupoUsuariosDetalle
@Id INT,
@IdGrupoUsuarios INT,
@IdUsuario INT
AS
BEGIN
    BEGIN TRY
        -- Verificar si el registro existe antes de actualizar
        IF EXISTS (SELECT 1 FROM GrupoUsuariosDetalle WHERE Id = @Id)
        BEGIN
            UPDATE GrupoUsuariosDetalle
            SET IdGrupoUsuarios = @IdGrupoUsuarios,
                IdUsuario = @IdUsuario
            WHERE Id = @Id;
        END
        ELSE
        BEGIN
            PRINT 'Error: El registro con el Id especificado no existe.';
        END
    END TRY
    BEGIN CATCH
        PRINT 'Error al actualizar GrupoUsuariosDetalle: ' + ERROR_MESSAGE();
    END CATCH
END;

--3. Procedimiento para eliminar grupo de usuario detalle.
CREATE PROCEDURE sp_DeleteGrupoUsuariosDetalle
@Id INT
AS
BEGIN
    BEGIN TRY
        -- Verificar si el registro existe antes de eliminar
        IF EXISTS (SELECT 1 FROM GrupoUsuariosDetalle WHERE Id = @Id)
        BEGIN
            DELETE FROM GrupoUsuariosDetalle WHERE Id = @Id;
        END
        ELSE
        BEGIN
            PRINT 'Error: El registro con el Id especificado no existe.';
        END
    END TRY
    BEGIN CATCH
        PRINT 'Error al eliminar GrupoUsuariosDetalle: ' + ERROR_MESSAGE();
    END CATCH
END;
