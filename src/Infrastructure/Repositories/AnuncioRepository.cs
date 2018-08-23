using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class AnuncioRepository : RepositoryBase<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(SistemaDbContext context)
            : base(context)
        {
             
        }

        public override void Remove(int id)
        {
            var entity = _repository.Anuncios.Find(id);
            entity.Ativo = false;
            _repository.Anuncios.Update(entity);
            _repository.SaveChanges();
        }
    }
}
