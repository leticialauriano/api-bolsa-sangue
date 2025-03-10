using core.API;
using GestaoBolsaSangue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.WebApi.Controllers
{
    public class AnimalController : ApiController
    {
        private readonly IAnimalService _service;
        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Animais")]
        public async Task<IActionResult> Listar()
        {
            var response = await _service.Listar();
            return ResponseHttp(response);
        }

        [HttpGet]
        [Route("Animal/{id:guid}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var response = await _service.Obter(id);
            return ResponseHttp(response);
        }
    }
}
