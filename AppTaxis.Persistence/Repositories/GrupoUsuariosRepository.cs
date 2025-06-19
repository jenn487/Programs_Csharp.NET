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
    public class GrupoUsuariosRepository : GenericRepository<GrupoUsuarios>, IGrupoUsuariosRepository
    {
        public GrupoUsuariosRepository(AppTaxiContext context) : base(context)
        {
        }

        public async Task<GrupoUsuarios> GetGrupoWithUsuariosAsync(int grupoId)
        {
            return await _dbSet
                .Include(g => g.GrupoUsuariosDetalles)
                .ThenInclude(gud => gud.Usuario)
                .FirstOrDefaultAsync(g => g.Id == grupoId);
        }

        public async Task<IEnumerable<GrupoUsuarios>> GetGruposWithUsuariosAsync()
        {
            return await _dbSet
                .Include(g => g.GrupoUsuariosDetalles)
                .ThenInclude(gud => gud.Usuario)
                .ToListAsync();
        }
    }
}