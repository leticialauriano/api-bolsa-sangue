using core.Messages;
using GestaoBolsaSangue.Domain.Interfaces;
using GestaoBolsaSangue.Domain.Shared.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.Infra.Data.Http.Repository
{
    public class ProprietarioHttpRepository : IProprietarioRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string URL_OBTER_PROPRIETARIO = "proprietario/{0}";
        public ProprietarioHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Proprietario> GetById(Guid id)
        {
            var queryString = string.Format(URL_OBTER_PROPRIETARIO, id);

            var httpResponse = await _httpClient.GetStringAsync(_httpClient.BaseAddress + queryString);
            var responseDeserialized = JsonConvert.DeserializeObject<BaseResponse<Proprietario>>(httpResponse);

            return responseDeserialized.Resultados;
        }
    }
}