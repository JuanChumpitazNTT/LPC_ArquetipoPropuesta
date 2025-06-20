using IBK.LPC.Infraestructure.DataInterface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IBK.LPC.Infraestructure.Data
{
    internal class ConectionFactory : IConectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetLPCConnection
        {
            get
            {
                var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                return connection;
            }
        }
    }
}
