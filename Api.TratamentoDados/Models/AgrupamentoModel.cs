using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.TratamentoDados.Models
{
    public class AgrupamentoModel
    {
        public string descricao { get; set; }
        public int quantidade { get; set; }

        public decimal precomedio { get; set; }
    }
}