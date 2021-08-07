using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThomasGreg.API.Inputs
{
    public class BaseInput
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }
    }
}
