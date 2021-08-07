using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public interface ILogradouroRepository
    {
        Task<Cliente> BuscarLogradouro(string email, string logradouro);
        Task InserirLogradouro(Cliente cliente);

        Task AtualizarLogradouro(Cliente cliente);

        Task RemoverLogradouro(string email, string logradouro);
    }
}
