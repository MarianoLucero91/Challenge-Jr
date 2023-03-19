using AdminPolizasAPI.Entidades;
using AdminPolizasAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace AdminPolizasAPI.Repositories
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PolizaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Poliza> GetAll()
        {
            return _dbContext.Polizas.ToList();
        }

        public Poliza? GetPolizaById(int id)
        {
            var poliza = _dbContext.Polizas.Where(c => c.Id == id).FirstOrDefault();

            return poliza;
        }

        public Poliza AddPoliza(Poliza model)
        {
            var poliza = _dbContext.Polizas.Add(model);
            _dbContext.SaveChanges();
            return poliza.Entity;
        }

        public void DeletePoliza(Poliza model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }

        public Poliza UpdatePoliza(Poliza model)
        {
            var poliza = _dbContext.Polizas.Include(p => p.PolizasCoberturas).Where(x => x.Id == model.Id).FirstOrDefault();

            if (poliza != null)
            {
                poliza.Nombre = model.Nombre;

                _dbContext.Polizas.Update(poliza);
                _dbContext.SaveChanges();

            }

            return poliza;
        }
    }
}
