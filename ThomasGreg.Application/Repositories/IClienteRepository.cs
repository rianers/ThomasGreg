using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> Buscar(string email);
        Task Inserir(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Remover(string email);
    }
}
