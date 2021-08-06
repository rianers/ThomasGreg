using System;

namespace ThomasGreg.Application
{
    public class ClienteNaoEncontradoException : Exception
    {
        public ClienteNaoEncontradoException(string email) : base($"{email} não encontrado. ")
        {
        }
    }
}
