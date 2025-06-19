using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTaxis.Application.DTOs;
using AppTaxis.Application.Interfaces;
using AppTaxis.Domain.Interfaces;
using AutoMapper;

namespace AppTaxis.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}