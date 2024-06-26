using Microsoft.AspNetCore.Mvc;
using my_finance_web.Models;
using my_finance_web_domain.Entities;
using my_finance_web_service.Interfaces;

namespace my_finance_web.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;
    private readonly IPlanoContaService _planoContaService;

    public PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService planoContaService)
    {
        _logger = logger;
        _planoContaService = planoContaService;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        var listaPlanoConta = _planoContaService.ListarRegistros();
        List<PlanoContaModel> listaPlanoContaModel = new List<PlanoContaModel>();
        foreach (var item in listaPlanoConta)
        {
            var planoContaModel = new PlanoContaModel()
            {
                Id = item.Id,
                Descricao = item.Descricao,
                Tipo = item.Tipo,
            };

            listaPlanoContaModel.Add(planoContaModel);
        }

        ViewBag.ListaPlanoConta = listaPlanoContaModel;
        return View();
    }

    [HttpGet]
    [Route("Cadastrar")]
    [Route("Cadastrar/{Id}")]
    public IActionResult Cadastrar(int? Id)
    {
        if (Id != null)
        {
            var planoConta = _planoContaService.RetornarRegistro((int)Id);
            var planoContaModel = new PlanoContaModel()
            {
                Id = planoConta.Id,
                Descricao = planoConta.Descricao,
                Tipo = planoConta.Tipo,
            };

            return View(planoContaModel);
        }
        else
        {
            return View();
        }
    }

    [HttpPost]
    [Route("Cadastrar")]
    [Route("Cadastrar/{Id}")]
    public IActionResult Cadastrar(PlanoContaModel model)
    {
        var planoConta = new PlanoConta()
        {
            Id = model.Id,
            Descricao = model.Descricao,
            Tipo = model.Tipo,
        };
        _planoContaService.Cadastrar(planoConta);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }

    [HttpGet]
    [Route("Excluir/{Id}")]
    public IActionResult Excluir(int? Id)
    {
        _planoContaService.Excluir((int)Id);
        return RedirectToAction("Index");
    }
}
