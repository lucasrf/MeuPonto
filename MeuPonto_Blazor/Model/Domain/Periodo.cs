using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Periodo
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public string Descricao { get { return GetDescricao(); } }
        public Periodo(DateTime reference)
        {
            Inicio = new DateTime(reference.Year, reference.Month, 1);
            Fim = Inicio.AddMonths(1).AddDays(-1);
        }
        public string GetDescricao()
        {
            return Inicio.Month.ToString() + "/" + Inicio.Year.ToString();
        }
    }
}
