using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Handler
{
    public class LogradouroHandler
    {
        private readonly IClienteRepository _clienteRepository;

        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroHandler(IClienteRepository clienteRepository, ILogradouroRepository logradouroRepository)
        {
            _clienteRepository = clienteRepository;
            _logradouroRepository = logradouroRepository;
        }

        public async Task<Cliente> BuscarLogradouro(string email, string logradouro)
        {
            ValidarCliente(email);

            var clienteLogradouro = await _logradouroRepository.BuscarLogradouro(email, logradouro);

            ValidarLogradouro(email, logradouro);

            return clienteLogradouro;
        }

        public async Task AdicionarLogradouro(string email, string logradouro)
        {
            Cliente cliente = await _clienteRepository.Buscar(email);

            ValidarCliente(email);

            cliente.AdicionarLogradouro(logradouro);

            await _logradouroRepository.InserirLogradouro(cliente);
        }

        public async Task AtualizarLogradouro(string email, string logradouroAntigo, string logradouroAtual)
        {
            Cliente cliente = await _clienteRepository.Buscar(email);

            ValidarCliente(email);

            ValidarLogradouro(email, logradouroAntigo);

            cliente.AtualizarLogradouro(logradouroAntigo, logradouroAtual);

            await _logradouroRepository.AtualizarLogradouro(cliente);
        }

        public async Task RemoverLogradouro(string email, string logradouro)
        {
            Cliente cliente = await _clienteRepository.Buscar(email);

            ValidarCliente(email);

            ValidarLogradouro(email, logradouro);

            cliente.RemoverLogradouro(logradouro);

            await _logradouroRepository.RemoverLogradouro(email, logradouro);
        }

        private void ValidarCliente(string email)
        {
            if (email == null)
                throw new ClienteNaoEncontradoException(email);
        }

        private void ValidarLogradouro(string email, string logradouro)
        {
            if (logradouro == null)
                throw new LogradouroNaoEncontradoException(logradouro, email);
        }
    }
}
