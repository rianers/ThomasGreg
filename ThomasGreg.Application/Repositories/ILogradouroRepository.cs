using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public interface ILogradouroRepository
    {
        Task<Logradouro> BuscarLogradouro(string email, string logradouro);
        Task<IEnumerable<Logradouro>> BuscarTodos(string email);
        Task InserirLogradouro(Logradouro logradouro);

        Task AtualizarLogradouro(Logradouro logradouro);

        Task RemoverLogradouro(Logradouro logradouro);
    }
}
