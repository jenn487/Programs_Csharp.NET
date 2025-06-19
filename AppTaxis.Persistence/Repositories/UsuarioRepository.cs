using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Domain.Entities;
using AppTaxis.Domain.Interfaces;
using AppTaxis.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppTaxis.Persistence.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppTaxiContext context) : base(context)
        {
        }

        public async Task<Usuario> GetByDocumentoAsync(string documento)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Documento == documento);
        }

        public async Task<bool> DocumentoExistsAsync(string documento)
        {
            return await _dbSet.AnyAsync(u => u.Documento == documento);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosWithViajesAsync()
        {
            return await _dbSet.Include(u => u.Viajes).ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByGrupoAsync(int grupoId)
        {
            return await _dbSet
                .Include(u => u.GrupoUsuariosDetalles)
                .Where(u => u.GrupoUsuariosDetalles.Any(gud => gud.IdGrupoUsuarios == grupoId))
                .ToListAsync();
        }
    }
}