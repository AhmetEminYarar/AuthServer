
//namespace AuthServer.MVC.Services
//{
//    public class ApiService
//    {
//        private readonly HttpClient _httpClient;

//        public ApiService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }
//        public async Task<string> GetApi()
//        {
//            var response = await _httpClient.GetAsync("Person");
//            response.EnsureSuccessStatusCode();

//            return await response.Content.ReadAsStringAsync();
//        }
//    }
//}
