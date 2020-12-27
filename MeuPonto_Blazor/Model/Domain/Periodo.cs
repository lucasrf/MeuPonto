using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Periodo
    {
        public DateTime Referencia { get; set; }
        public string Descricao { get { return GetDescricao(); } }

        public string GetDescricao()
        {
            return Referencia.Month.ToString() + "/" + Referencia.Year.ToString();
        }
    }
}
