namespace Core.Model
{
    public class User
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string GetUserName() => username;
        public string GetPassword() => password;
    }
}
