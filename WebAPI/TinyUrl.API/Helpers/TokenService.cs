namespace TinyUrl.API.Helpers
{
    public class TokenService
    {
        private readonly IConfiguration _configuration; 
        public TokenService(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }
        public string GetSecretToken() {

            return _configuration["SecretToken"]; 
        }
    }
}
