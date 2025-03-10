using core.Messages;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace core.API
{
    public abstract class ApiController : ControllerBase
    {
        private readonly BaseResponse<object> restResult = new BaseResponse<object>() { Valido = true };

        public IActionResult ResponseHttp(ValidationResult retorno = null)
        {
            if (!retorno.IsValid)
                restResult.AdicionarMensagensErros(retorno);

            return RestResult(restResult);
        }

        public IActionResult ResponseHttp(object response = null)
        {
            restResult.Resultados = response;
            restResult.Valido = true;

            return RestResult(restResult);
        }

        private IActionResult RestResult(BaseResponse<object> response = null)
        {
            if (!response.Valido)
                return BadRequest(response);

            return Ok(restResult);
        }

        #region MetodosAuxiliares

        public IActionResult ResponseRequetErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                restResult.AdicionarMensagemErro(erroMsg);
            }

            return RestResult(restResult);
        }

        #endregion
    }
}
