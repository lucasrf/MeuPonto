using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto_Blazor
{
    public class Funcionario
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        public List<Ponto> Pontos { get; set; } = new List<Ponto>();

        public Funcionario(string nome, int codigo)
        {
            Codigo = 0;
            Nome = nome;
            Codigo = codigo;
        }

        public List<Ponto> GetPontosByPeriodo(Periodo periodo)
        {
            List<Ponto> pontos = new List<Ponto>();
            foreach (var ponto in Pontos)
            {
                if (ponto.Date >= periodo.Inicio && ponto.Date <= periodo.Fim)
                {
                    pontos.Add(ponto);
                }
            }
            return pontos;
        }
    }
}
