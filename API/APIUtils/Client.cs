using RestSharp;

namespace API.APIUtils
{
    public class Client
    {
        private static string BASE_URL = @"https://en.wikipedia.org/api/rest_v1/";
        private static Client _currentClient;
        private static RestClient _Client;

        private Client()
        {
            _Client = new RestClient(BASE_URL);
        }

        public static Client Instance => _currentClient ?? (_currentClient = new Client());

        public static RestClient GetClient => _Client;

        public static void QuitClient()
        {
            _currentClient = null;
            _Client = null;
        }
    }
}
