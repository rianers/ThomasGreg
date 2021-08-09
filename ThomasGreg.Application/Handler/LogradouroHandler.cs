using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Application.Handler
{
    public class LogradouroHandler
    {

        private readonly ILogradouroRepository _logradouroRepository;

        public LogradouroHandler(ILogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;
        }

        public async Task<Logradouro> BuscarLogradouro(string email, string logradouroNome)
        {
            Logradouro logradouro = await _logradouroRepository.BuscarLogradouro(email, logradouroNome);

            ValidarLogradouro(logradouro);

            return logradouro;
        }

        public async Task<IEnumerable<Logradouro>> BuscarTodos(string email)
        {
            IEnumerable<Logradouro> logradouros = await _logradouroRepository.BuscarTodos(email);

            return logradouros;
        }

        public async Task AdicionarLogradouro(string email, string logradouroNome)
        {
            Logradouro logradouro = new Logradouro(email, logradouroNome);

            await _logradouroRepository.InserirLogradouro(logradouro);
        }

        public async Task AtualizarLogradouro(string email, string logradouroAntigo, string logradouroAtual)
        {
            Logradouro logradouro = await _logradouroRepository.BuscarLogradouro(email, logradouroAntigo);

            ValidarLogradouro(logradouro);

            logradouro.AtualizarLogradouro(logradouroAtual);

            await _logradouroRepository.AtualizarLogradouro(logradouro);
        }

        public async Task RemoverLogradouro(string email, string logradouroNome)
        {
            Logradouro logradouro = await _logradouroRepository.BuscarLogradouro(email, logradouroNome);

            ValidarLogradouro(logradouro);

            Logradouro logradouroAtual = new Logradouro(logradouroNome, email);

            await _logradouroRepository.RemoverLogradouro(logradouroAtual);
        }

        private void ValidarLogradouro(Logradouro logradouro)
        {
            if (logradouro == null)
                throw new LogradouroNaoEncontradoException();
        }
    }
}
