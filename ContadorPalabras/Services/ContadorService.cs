using ContadorPalabras.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContadorPalabras.Services
{
    public class ContadorService
    {
        public HttpClient Client = new HttpClient();
        public ContadorService(string apiURL)
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.BaseAddress = new Uri(apiURL);
        }

        public async Task<ResultadoDTO> ContarPalabras(string texto)
        {
            try
            {
                StringContent content = new StringContent(JsonSerializer.Serialize(texto), Encoding.UTF8, "application/json");
                HttpResponseMessage response = Client.PostAsync("Contador/ContarPalabras", content).Result;

                if(response.IsSuccessStatusCode == false)
                {
                    return new ResultadoDTO("Error de conexión del API REST: " + response.RequestMessage.RequestUri);
                }

                var result = await response.Content.ReadAsStreamAsync();           

                ResultadoDTO resultMessage = await JsonSerializer.DeserializeAsync<ResultadoDTO>(result);
                return resultMessage;
            }
            catch (Exception ex)
            {
                return new ResultadoDTO(ex.Message);
            }
        }
    }
}
