using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaDbContext _repository;

        public UsuarioRepository(SistemaDbContext repository)
        {
            _repository = repository;
        }
        
        public Usuario GetById(Guid id)
        {
            return _repository.Users.Find(id);
        }
    }
}
