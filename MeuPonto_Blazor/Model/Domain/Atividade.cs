using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Atividade
    {
        public string Descricao { get; set; }
        public TimeSpan Tempo { get; set; }
        public Atividade(TimeSpan tempo, string descricao = "")
        {
            Descricao = descricao;
            Tempo = tempo;
        }
    }
}
