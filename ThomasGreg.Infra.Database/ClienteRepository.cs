using System;
using System.Threading.Tasks;
using ThomasGreg.Application.Repositories;
using ThomasGreg.Domain;

namespace ThomasGreg.Infra.Database
{
    public class ClienteRepository : IClienteRepository
    {
        public Task Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Buscar(string email)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task Remover(string email)
        {
            throw new NotImplementedException();
        }
    }
}
