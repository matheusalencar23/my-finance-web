using my_finance_web_domain.Entities;

namespace my_finance_web_service.Interfaces;
public interface ITransacaoService
{
    void Cadastrar(Transacao Entidade);

    void Excluir(int Id);

    List<Transacao> ListarRegistros();

    Transacao RetornarRegistro(int Id);
}
