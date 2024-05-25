using my_finance_web_domain.Entities;

namespace my_finance_web_service.Interfaces
{
    public interface IPlanoContaService
    {
        void Cadastrar(PlanoConta Entidade);

        void Excluir(int Id);

        List<PlanoConta> ListarRegistros();

        PlanoConta RetornarRegistro(int Id);
    }
}