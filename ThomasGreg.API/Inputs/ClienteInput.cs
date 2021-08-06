using System.ComponentModel.DataAnnotations;

namespace ThomasGreg.API.Inputs
{
    public class ClienteInput
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Logotipo { get; private set; }
        public string Logradouro { get; private set; }
    }
}
