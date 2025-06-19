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
    public class GrupoUsuariosDetalleRepository : GenericRepository<GrupoUsuariosDetalle>, IGrupoUsuariosDetalleRepository
    {
        public GrupoUsuariosDetalleRepository(AppTaxiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GrupoUsuariosDetalle>> GetByGrupoAsync(int grupoId)
        {
            return await _dbSet
                .Include(gud => gud.Usuario)
                .Include(gud => gud.GrupoUsuarios)
                .Where(gud => gud.IdGrupoUsuarios == grupoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<GrupoUsuariosDetalle>> GetByUsuarioAsync(int usuarioId)
        {
            return await _dbSet
                .Include(gud => gud.Usuario)
                .Include(gud => gud.GrupoUsuarios)
                .Where(gud => gud.IdUsuario == usuarioId)
                .ToListAsync();
        }

        public async Task<bool> UsuarioEnGrupoAsync(int usuarioId, int grupoId)
        {
            return await _dbSet.AnyAsync(gud => gud.IdUsuario == usuarioId && gud.IdGrupoUsuarios == grupoId);
        }

        public async Task<bool> RemoveUsuarioFromGrupoAsync(int usuarioId, int grupoId)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(gud => gud.IdUsuario == usuarioId && gud.IdGrupoUsuarios == grupoId);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<GrupoUsuariosDetalle> AddUsuarioToGrupoAsync(GrupoUsuariosDetalle nuevoDetalle)
        {
            await _dbSet.AddAsync(nuevoDetalle);
            await _context.SaveChangesAsync();
            return nuevoDetalle;
        }

        public async Task<bool> UpdateUsuarioGrupoAsync(int id, int nuevoGrupoId)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(gud => gud.Id == id);
            if (entity == null)
                return false;

            entity.IdGrupoUsuarios = nuevoGrupoId;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}