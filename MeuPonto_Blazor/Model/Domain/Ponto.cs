using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto_Blazor
{
    public class Ponto
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public List<Atividade> Atividades { get; set; } = new List<Atividade>();
        public List<Marcacao> Marcacoes { get; set; } = new List<Marcacao>();
        public string Observacao { get; set; }
        public Ponto(DateTime date)
        {
            Codigo = 0;
            Date = date;
            Atividades = new List<Atividade>();
            Marcacoes = new List<Marcacao>();
            Observacao = "-";
        }
    }
}
