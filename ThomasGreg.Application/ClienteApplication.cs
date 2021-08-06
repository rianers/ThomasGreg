using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public class ClienteApplication
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> BuscarCliente(string email)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);

            if (clienteEmail != null)
                throw new ClienteNaoEncontradoException(email);

            return await _clienteRepository.Buscar(email);
        }

        public async Task InserirCliente(string nome, string email, string logotipo, string logradouro)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);

            if (clienteEmail != null)
                throw new ClienteNaoEncontradoException(email);

            Cliente cliente = new Cliente(nome, email, logotipo, logradouro);

            await _clienteRepository.Inserir(cliente);
        }

        public async Task AtualizarCliente(string nome, string email, string logotipo)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);

            if (clienteEmail != null)
                throw new ClienteNaoEncontradoException(email);

            Cliente cliente = new Cliente(nome, email, logotipo);

            await _clienteRepository.Atualizar(cliente);
        }

        public async Task RemoverCliente(string email)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);

            if (clienteEmail != null)
                throw new ClienteNaoEncontradoException(email);

            await _clienteRepository.Remover(email);
        }
    }
}
