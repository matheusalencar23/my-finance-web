using Microsoft.AspNetCore.Mvc.Rendering;
using my_finance_web_domain.Entities;

namespace my_finance_web.Models;

public class TransacaoModel
{
    public int? Id { get; set; }
    public string Historico { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public int PlanoContaId { get; set; }
    public IEnumerable<SelectListItem>? ListaPlanoConta { get; set; }
    public string Tipo { get; set; }
}
