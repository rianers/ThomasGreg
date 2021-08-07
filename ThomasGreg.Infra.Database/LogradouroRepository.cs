using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Infra.Database
{
    public class LogradouroRepository : ILogradouroRepository
    {
        public Task AtualizarLogradouro(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> BuscarLogradouro(string email, string logradouro)
        {
            throw new NotImplementedException();
        }

        public Task InserirLogradouro(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task RemoverLogradouro(string email, string logradouro)
        {
            throw new NotImplementedException();
        }
    }
}
