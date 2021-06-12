using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Base.Models
{
    public class MassaDadosModel
    {
        public int id { get; set; }

        public string datetime { get; set; }

        public string tipoOperacao { get; set; }

        public string ativo { get; set; }
        public int quantidade { get; set; }

        public decimal preco { get; set; }

        public int conta { get; set; }

        public MassaDadosModel()
        {

        }

    }
}