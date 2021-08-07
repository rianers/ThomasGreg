using System.ComponentModel.DataAnnotations;

namespace ThomasGreg.API.Inputs
{
    public class BaseInput
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
    }
}
