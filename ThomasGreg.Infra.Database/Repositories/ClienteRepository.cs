using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Infra.Database.Repositories
{
    public class ClienteRepository : Context, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Atualizar(Cliente cliente)
        {
            string query = @"UPDATE 
                                Cliente 
                             SET    
                                Nome = @Nome,
                                Logotipo = @Logotipo
                             WHERE 
                                Email = @email";

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            var param = new
            {
                cliente.Nome,
                cliente.Logotipo,
                cliente.Email
            };

            await con.ExecuteAsync(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task<Cliente> Buscar(string email)
        {
            string query = @"SELECT Nome, Email, Logotipo FROM Cliente (NOLOCK) WHERE Email = @email";

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            var param = new
            {
                email
            };

            return await con.QueryFirstOrDefaultAsync<Cliente>(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task Inserir(Cliente cliente)
        {
            string query = @"INSERT INTO Cliente (Nome, Email, Logotipo) VALUES(@Nome, @Email, @Logotipo);";

            var param = new
            {
                cliente.Nome,
                cliente.Email,
                cliente.Logotipo
            };

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            await con.ExecuteAsync(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task Remover(string email)
        {
            string query = @"DELETE FROM Cliente WHERE Email = @email";

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            var param = new
            {
                email
            };

            await con.ExecuteAsync(query, param, commandType: System.Data.CommandType.Text);
        }
    }
}
