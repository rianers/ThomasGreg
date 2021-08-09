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
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Logotipo { get; private set; }

        public void AtualizarCliente(Cliente cliente)
        {
            Email = cliente.Email;
            Logotipo = cliente.Logotipo;
        }
    }
}
