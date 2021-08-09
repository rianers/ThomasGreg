namespace ThomasGreg.Domain
{
    public class Logradouro
    {
        public Logradouro(string logradouroNome, string email)
        {
            LogradouroNome = logradouroNome;
            Email = email;
        }
        public Logradouro()
        {
        }
        public string LogradouroNome { get; private set; }
        public string Email { get; private set; }

        public void AtualizarLogradouro(string logradouro) => LogradouroNome = logradouro;
    }
}
