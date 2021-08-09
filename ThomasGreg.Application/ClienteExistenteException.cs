using System;

namespace ThomasGreg.Application
{
    public class ClienteExistenteException : Exception
    {
        public ClienteExistenteException(string email) : base($"Já existe um cadastro para o cliente com o email {email}. ")
        {
        }
    }
}
