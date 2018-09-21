using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public bool IsActive(string email)
        {
            return _repository.IsActive(email);
        }

        public Usuario GetById(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
