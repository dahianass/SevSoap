using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSoap
{
    public class resultDto
    {

        public bool Error { get; set; }
        public string mensage { get; set; }
        public string resultado { get; set; }

        public resultDto(bool Err , string msn , string resul)
        {
            Error = Err;
            mensage = msn;
            resultado = resul;
        }
    }
}