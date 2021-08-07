using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThomasGreg.API.Inputs
{
    public class LogradouroInput : BaseInput
    {
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string Logradouro { get; set; }
    }
}
