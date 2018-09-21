﻿using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario GetById(Guid id);
        bool IsActive(string email);
    }
}
