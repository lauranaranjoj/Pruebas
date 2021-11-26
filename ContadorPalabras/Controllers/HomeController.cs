using ContadorPalabras.Models;
using ContadorPalabras.Services;
using ContadorPalabras.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContadorPalabras.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ContadorService _service;

        public HomeController(ILogger<HomeController> logger,
                              IConfiguration configuration)
        {
            _logger = logger;
            _service = new ContadorService(configuration.GetValue<string>("ApiContador"));

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> ContarPalabras(string texto)
        {
            ResultadoDTO objResultado = await _service.ContarPalabras(texto);

            return Json(objResultado);
        }
    }
}
