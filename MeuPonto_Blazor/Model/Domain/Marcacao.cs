using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Marcacao
    {
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public string Descricao { get; set; }
        public TimeSpan GetIntervalo() => Fim - Inicio;
        public Marcacao(TimeSpan inicio, TimeSpan fim, string descricao = "")
        {
            Inicio = inicio;
            Fim = fim;
            Descricao = descricao;
        }
    }
}
