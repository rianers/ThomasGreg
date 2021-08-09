using System.Threading.Tasks;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Repositories
{
    public class ClienteHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> BuscarCliente(string email)
        {
            var cliente = await _clienteRepository.Buscar(email);

            ValidarCliente(cliente, email);

            return cliente;
        }

        public async Task InserirCliente(string nome, string email, string logotipo)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);

            if (clienteEmail != null)
                throw new ClienteExistenteException(email);

            Cliente cliente = new Cliente(nome, email, logotipo);

            await _clienteRepository.Inserir(cliente);
        }

        public async Task AtualizarCliente(string nome, string email, string logotipo)
        {
            var clienteEmail = await _clienteRepository.Buscar(email);

            ValidarCliente(clienteEmail, email);

            Cliente cliente = new Cliente(nome, email, logotipo);

            await _clienteRepository.Atualizar(cliente);
        }

        public async Task RemoverCliente(string email)
        {
            var cliente = await _clienteRepository.Buscar(email);

            ValidarCliente(cliente, email);

            await _clienteRepository.Remover(email);
        }

        private void ValidarCliente(Cliente cliente, string email)
        {
            if (cliente == null)
                throw new ClienteNaoEncontradoException(email);
        }
    }
}
