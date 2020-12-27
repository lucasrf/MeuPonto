using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Ponto
    {
        public DateTime Date { get; set; }
        public List<Atividade> Atividades { get; set; } = new List<Atividade>();
        public List<Marcacao> Marcacoes { get; set; } = new List<Marcacao>();
        public string Observacao { get; set; }
        public Ponto(DateTime date)
        {
            Date = date;
            Atividades = new List<Atividade>();
            Marcacoes = new List<Marcacao>();
            Observacao = "-";
        }
    }
}
