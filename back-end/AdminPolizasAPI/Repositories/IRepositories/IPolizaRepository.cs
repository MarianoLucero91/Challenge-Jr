using AdminPolizasAPI.Entidades;

namespace AdminPolizasAPI.Repositories.IRepositories
{       
    public interface IPolizaRepository
    {
        Poliza? GetPolizaById(int id);
        List<Poliza> GetAll();
        Poliza AddPoliza(Poliza model);
        void DeletePoliza(Poliza model);
        Poliza UpdatePoliza(Poliza model);
    }
}
