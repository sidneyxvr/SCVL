using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public VendaRepository(SistemaDbContext repository)
            : base(repository)
        {

        }
    }
}
