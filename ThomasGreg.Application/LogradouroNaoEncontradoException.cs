using System;

namespace ThomasGreg.Application
{
    public class LogradouroNaoEncontradoException : Exception
    {
        public LogradouroNaoEncontradoException(string logradouro, string email) : base($"{logradouro} não foi encontrado para o cliente {email}.")
        {
        }
    }
}
