using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Repositories.IRepositories;
using System.Linq;

namespace AdminPolizasAPI.Repositories
{
    public class CoberturaRepository : ICoberturaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CoberturaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;           
        }

        public List<Cobertura> GetAll()
        {
            return _dbContext.Coberturas.ToList();
        }

        public Cobertura? GetCoberturaById(int id)
        {
            var cobertura = _dbContext.Coberturas.Where(c => c.Id == id).FirstOrDefault();

            return cobertura;
        }

        public Cobertura AddCobertura(Cobertura model)
        {
           var cobertura = _dbContext.Coberturas.Add(model);
           _dbContext.SaveChanges();
           return cobertura.Entity;
        }

        public void DeleteCobertura(Cobertura model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }

        public Cobertura UpdateCobertura(Cobertura model)
        {
            var cobertura = _dbContext.Coberturas.Where(x => x.Id == model.Id).FirstOrDefault();
            if (cobertura != null)
            {
                cobertura.Nombre = model.Nombre;
               
                _dbContext.Coberturas.Update(cobertura);
                _dbContext.SaveChanges();
                
            }
            
            return cobertura;
        }
    }
}
