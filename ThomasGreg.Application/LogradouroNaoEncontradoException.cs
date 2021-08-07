using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application
{
    public class LogradouroNaoEncontradoException : Exception
    {
        public LogradouroNaoEncontradoException(string logradouro, string email) : base ($"{logradouro} não foi encontrado para o cliente {email}.")
        {
        }
    }
}
