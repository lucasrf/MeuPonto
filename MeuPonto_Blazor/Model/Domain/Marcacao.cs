using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Marcacao
    {
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public TimeSpan GetIntervalo() => Fim - Inicio;
        public Marcacao(DateTime inicio, DateTime fim, string descricao = "")
        {
            Inicio = inicio;
            Fim = fim;
            Descricao = descricao;
        }
    }
}
