using System;

namespace ThomasGreg.Application
{
    public class LogradouroNaoEncontradoException : Exception
    {
        public LogradouroNaoEncontradoException() : base("Logradouro não encontrado.")
        {
        }
    }
}
