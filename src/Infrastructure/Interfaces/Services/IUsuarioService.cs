using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario GetById(Guid id);
        bool IsActive(string email);
    }
}
