using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Infra.Database.Repositories
{
    public class LogradouroRepository : Context, ILogradouroRepository
    {
        public LogradouroRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task AtualizarLogradouro(Logradouro logradouro)
        {
            string query = @"UPDATE 
                                Logradouro 
                             SET     
                                LogradouroNome = @LogradouroNome
                             WHERE 
                                Email = @email";

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            var param = new
            {
                logradouro.LogradouroNome,
                logradouro.Email
            };

            await con.ExecuteAsync(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task<Logradouro> BuscarLogradouro(string email, string logradouro)
        {
            string query = @"SELECT LogradouroNome, Email FROM Logradouro (NOLOCK) WHERE Email = @email AND LogradouroNome = @logradouro";

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            var param = new
            {
                email,
                logradouro
            };

            return await con.QueryFirstOrDefaultAsync<Logradouro>(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<Logradouro>> BuscarTodos(string email)
        {
            string query = @"SELECT LogradouroNome, Email FROM Logradouro (NOLOCK) WHERE Email = @email";

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            var param = new
            {
                email
            };

            return await con.QueryAsync<Logradouro>(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task InserirLogradouro(Logradouro logradouro)
        {
            string query = @"INSERT INTO Logradouro (LogradouroNome, Email) VALUES(@LogradouroNome, @Email);";

            var param = new
            {
                logradouro.LogradouroNome,
                logradouro.Email
            };

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            await con.ExecuteAsync(query, param, commandType: System.Data.CommandType.Text);
        }

        public async Task RemoverLogradouro(Logradouro logradouro)
        {
            string query = @"DELETE FROM Logradouro WHERE Email = @email AND LogradouroNome = @LogradouroNome";

            using var con = new SqlConnection(Conn());

            await con.OpenAsync();

            var param = new
            {
                logradouro.Email,
                logradouro.LogradouroNome
            };

            await con.ExecuteAsync(query, param, commandType: System.Data.CommandType.Text);
        }
    }
}
