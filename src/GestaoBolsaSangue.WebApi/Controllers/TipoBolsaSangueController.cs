using core.API;
using GestaoBolsaSangue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.WebApi.Controllers
{
    public class TipoBolsaSangueController : ApiController
    {
        private readonly ITipoBolsaSangueService _service;
        public TipoBolsaSangueController(ITipoBolsaSangueService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("TiposBolsaSangues")]
        public async Task<IActionResult> Listar()
        {
            var response = await _service.Listar();
            return ResponseHttp(response);
        }

        [HttpGet]
        [Route("TipoBolsaSangue/{id:guid}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var response = await _service.Obter(id);
            return ResponseHttp(response);
        }
    }
}
