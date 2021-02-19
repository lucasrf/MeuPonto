using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto_Blazor
{
    public class Atividade
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public TimeSpan Tempo { get; set; }
        public Atividade(TimeSpan tempo, string descricao = "")
        {
            Codigo = 0;
            Descricao = descricao;
            Tempo = tempo;
        }
    }
}
