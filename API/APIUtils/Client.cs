using RestSharp;

namespace API.APIUtils
{
    public class Client
    {
        private static Client _currentClient;
        private static RestClient _Client;

        private Client()
        {
            _Client = new RestClient();
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
