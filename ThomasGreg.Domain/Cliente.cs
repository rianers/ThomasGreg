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
            Logradouro = new List<string>();
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

        public void AtualizarLogradouro(string logradouroAntigo, string logradouroAtual)
        {
            bool item = Logradouro.Contains(logradouroAntigo);

            if (item == true)
            {
                var indice = Logradouro.IndexOf(logradouroAntigo);
                Logradouro[indice] = logradouroAtual;
                return;
            }

            Logradouro.Add(logradouroAtual);
        }

        public void RemoverLogradouro(string logradouro)
        {
            Logradouro.Remove(logradouro);
        }

    }
}
