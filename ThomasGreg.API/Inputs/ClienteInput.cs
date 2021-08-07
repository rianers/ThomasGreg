﻿using System.ComponentModel.DataAnnotations;

namespace ThomasGreg.API.Inputs
{
    public class ClienteInput : BaseInput
    {
       
        public string Nome { get; set; }
        public string Logotipo { get; set; }
        public string Logradouro { get; set; }
    }
}
