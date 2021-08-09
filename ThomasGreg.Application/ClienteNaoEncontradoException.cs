using System;

namespace ThomasGreg.Application
{
    public class ClienteNaoEncontradoException : Exception
    {
        public ClienteNaoEncontradoException(string email) : base($"O cliente com o email {email} não foi encontrado. ")
        {
        }
    }
}
