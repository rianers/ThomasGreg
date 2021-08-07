using System.ComponentModel.DataAnnotations;

namespace ThomasGreg.API.Inputs
{
    public class LogradouroInput : BaseInput
    {
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string Logradouro { get; set; }
    }
}
