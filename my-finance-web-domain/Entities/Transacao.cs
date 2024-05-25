﻿namespace my_finance_web_domain.Entities;
public class Transacao
{
    public int? Id { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public int PlanoContaId { get; set; }
    public PlanoConta PlanoConta { get; set; }
}
