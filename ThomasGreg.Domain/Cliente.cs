using System;
using System.Collections.Generic;

namespace ThomasGreg.Domain
{
    public class Cliente
    {
        public Cliente(string nome, string email, string logotipo)
        {
            Nome = nome;
            Email = email;
            Logotipo = logotipo;
        }
        public Cliente(string nome, string email, string logotipo, string logradouro) : this(nome, email, logotipo)
        {
            Nome = nome;
            Email = email;
            Logotipo = logotipo;
            Logradouro.Add(logradouro);
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Logotipo { get; private set; }
        public List<string> Logradouro { get; private set; }

        public void AdicionarLogradouro(string logradouro)
        {
            Logradouro.Add(logradouro);
        }

        public void AtualizarLogradouro(string logradouro)
        {
            bool item = Logradouro.Contains(logradouro);

            var indice = Logradouro.IndexOf(logradouro);

            if (item == true)
            {
                Logradouro[indice] = logradouro;
                return;
            }

            Logradouro.Add(logradouro);
        }

        public void RemoverLogradouro(string logradouro)
        {
            Logradouro.Remove(logradouro);
        }

    }
}
