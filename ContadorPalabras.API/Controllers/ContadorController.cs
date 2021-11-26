using ContadorPalabras.Service;
using ContadorPalabras.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContadorPalabras.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorController : ControllerBase
    {

        ContadorService _service;

        public ContadorController()
        {
            _service = new ContadorService();
        }

        [HttpPost]
        [Route("ContarPalabras")]
        public IActionResult GetByFilters( [FromBody] string texto)
        {
            return Ok(_service.ContarPalabras(texto));
        }

    }
}
