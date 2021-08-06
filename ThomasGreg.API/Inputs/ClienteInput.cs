using System.ComponentModel.DataAnnotations;

namespace ThomasGreg.API.Inputs
{
    public class ClienteInput
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Logotipo { get; set; }
        public string Logradouro { get; set; }
    }
}
