using Microsoft.Extensions.Configuration;

namespace ThomasGreg.Infra.Database
{
    public class Context
    {
        private readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected string Conn()
        {
            return _configuration.GetSection("ConnectionStrings").GetSection("DatabaseSQL").Value;
        }
    }
}
