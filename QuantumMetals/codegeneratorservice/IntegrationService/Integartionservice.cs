using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using codegeneratorservice.Model;
using Newtonsoft.Json;

namespace codegeneratorservice.IntegrationService
{
    public class Integartionservice : IIntegrationservice
    {
        private readonly IConfiguration _configuration;
        public Integartionservice(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseMessage> GetData()
        {

            // call the external service to store the data;
            string strBaseUrl = _configuration.GetValue<string>("StorageEndPoint:URL");
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClient _httpClient = new HttpClient(httpClientHandler);
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{strBaseUrl}api/StorageService/Storage");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                //ResponseMessage responseObject = JsonSerializer.Deserialize<ResponseMessage>(content);
                ResponseMessage responseObject = JsonConvert.DeserializeObject<ResponseMessage>(content);
                return responseObject;
            }
            catch (Exception ex)
            {
                //
                return new ResponseMessage { Message = ex.Message, statusCode = 400 };
            }

        }


        public async Task<ResponseMessage> AddCodeToStorage(List<UniqueCodeDTO> lstUniqueCode)
        {
            // call the external service to store the data;
            string strBaseUrl = _configuration.GetValue<string>("StorageEndPoint:URL");
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            HttpClient _httpClient = new HttpClient(httpClientHandler);
            try
            {

                string uniqueCode = System.Text.Json.JsonSerializer.Serialize(lstUniqueCode);
                var request = new HttpRequestMessage(HttpMethod.Post, $"{strBaseUrl}api/StorageService/Storage");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(uniqueCode, Encoding.UTF8);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                ResponseMessage responseObject = System.Text.Json.JsonSerializer.Deserialize<ResponseMessage>(content);
                return responseObject;
            }
            catch (Exception ex)
            {
                //
                return new ResponseMessage { Message = ex.Message, statusCode = 400 };
            }
        }
    }
}