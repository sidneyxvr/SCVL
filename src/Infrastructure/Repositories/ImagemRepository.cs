using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ImagemRepository : RepositoryBase<Imagem>, IImagemRepository
    {
        public ImagemRepository(SistemaDbContext context)
            : base(context)
        {
        
        }

        public override void Update(Imagem imagem)
        {
            _repository.Entry(imagem).Property(i => i.Caminho).IsModified = true;
            _repository.SaveChanges(); 
        }
    }
}
