﻿using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Services
{
    public interface IAnuncioService
    {
        void Add(Anuncio anuncio);
        void Update(Anuncio anuncio);
        void Remove(int id);
        Anuncio GetById(int id);
        IEnumerable<Anuncio> GetAll();
    }
}
