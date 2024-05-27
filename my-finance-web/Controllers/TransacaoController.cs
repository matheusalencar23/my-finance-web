using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using my_finance_web.Models;
using my_finance_web_domain.Entities;
using my_finance_web_service.Interfaces;

namespace my_finance_web.Controllers;

[Route("[controller]")]
public class TransacaoController : Controller
{
    private readonly ILogger<TransacaoController> _logger;
    private readonly ITransacaoService _transacaoService;
    private readonly IPlanoContaService _planoContaService;

    public TransacaoController(ILogger<TransacaoController> logger, ITransacaoService transacaoService, IPlanoContaService planoContaService)
    {
        _logger = logger;
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var listaTransacao = _transacaoService.ListarRegistros();
        List<TransacaoModel> listaTransacaoModel = new List<TransacaoModel>();
        foreach (var item in listaTransacao)
        {
            var transacaoModel = new TransacaoModel()
            {
                Id = item.Id,
                Historico = item.Historico,
                Valor = item.Valor,
                Data = item.Data,
                PlanoContaId = item.PlanoContaId,
                Tipo = item.PlanoConta.Tipo
            };

            listaTransacaoModel.Add(transacaoModel);
        }

        ViewBag.ListaTransacao = listaTransacaoModel;
        return View();
    }

    [HttpGet]
    [Route("Cadastrar")]
    [Route("Cadastrar/{Id}")]
    public IActionResult Cadastrar(int? Id)
    {
        var listaPlanoConta = new SelectList(_planoContaService.ListarRegistros(), "Id", "Descricao");
        var transacaoModel = new TransacaoModel()
        {
            Data = DateTime.Now,
            ListaPlanoConta = listaPlanoConta
        };

        if (Id != null)
        {
            var transacao = _transacaoService.RetornarRegistro((int)Id);
            transacaoModel.Id = transacao.Id;
            transacaoModel.Historico = transacao.Historico;
            transacaoModel.Valor = transacao.Valor;
            transacaoModel.Data = transacao.Data;
            transacaoModel.PlanoContaId = transacao.PlanoContaId;
        }

        return View(transacaoModel);
    }

    [HttpPost]
    [Route("Cadastrar")]
    [Route("Cadastrar/{Id}")]
    public IActionResult Cadastrar(TransacaoModel model)
    {
        var transacao = new Transacao()
        {
            Id = model.Id,
            Historico = model.Historico,
            Valor = model.Valor,
            Data = model.Data,
            PlanoContaId = model.PlanoContaId,
        };
        _transacaoService.Cadastrar(transacao);
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("Excluir/{Id}")]
    public IActionResult Excluir(int? Id)
    {
        _transacaoService.Excluir((int)Id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
