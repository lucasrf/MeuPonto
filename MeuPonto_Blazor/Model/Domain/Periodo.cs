using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto_Blazor
{
    public class Periodo
    {
        [Key]
        public int Codigo { get; set; }
        public DateTime Referencia { get; set; }
        public DateTime Inicio { get { return new DateTime(Referencia.Year, Referencia.Month, 1); } }
        public DateTime Fim { get { return Inicio.AddMonths(1).AddDays(-1); } }
        public string Descricao { get { return GetDescricao(); } }

        public Periodo(DateTime referencia)
        {
            Codigo = 0;
            Referencia = referencia;
        }
        public string GetDescricao()
        {
            return Inicio.Month.ToString() + "/" + Inicio.Year.ToString();
        }
    }
}
