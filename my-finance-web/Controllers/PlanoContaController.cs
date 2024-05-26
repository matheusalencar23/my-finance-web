using Microsoft.AspNetCore.Mvc;
using my_finance_web.Models;
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
