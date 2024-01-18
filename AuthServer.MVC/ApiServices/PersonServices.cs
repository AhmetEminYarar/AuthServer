namespace AuthServer.MVC.ApiServices
{
    public class PersonServices
    {
        private readonly HttpClient _httpClient;

        public PersonServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetApi()
        {
            var response = await _httpClient.GetAsync("Person");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
