using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool IsActive(string email)
        {
            var user = _repository.Users.Where(a => a.Email == email);
            if (user.Count() > 0)
            {
                return user.First().Ativo;
            }
            return false;
        }

        public Usuario GetById(Guid id)
        {
            return _repository.Users.Find(id);
        }
    }
}
