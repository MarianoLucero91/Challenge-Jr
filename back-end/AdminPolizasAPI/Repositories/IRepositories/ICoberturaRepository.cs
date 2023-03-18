using AdminPolizasAPI.Entidades;

namespace AdminPolizasAPI.Repositories.IRepositories
{
    public interface ICoberturaRepository
    {
        Cobertura? GetCoberturaById (int id);
        List<Cobertura> GetAll();
        Cobertura AddCobertura(Cobertura model);
        void DeleteCobertura(Cobertura model);
        Cobertura UpdateCobertura(Cobertura model);
    }
}
