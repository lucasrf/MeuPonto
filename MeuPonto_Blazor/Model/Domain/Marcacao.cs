using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto_Blazor
{
    public class Marcacao
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public TimeSpan Inicio { get; set; }
        [Required]
        public TimeSpan Fim { get; set; }
        [Required]
        public string Descricao { get; set; }
        public TimeSpan GetIntervalo() => Fim - Inicio;
        public Marcacao(TimeSpan inicio, TimeSpan fim, string descricao = "")
        {
            Codigo = 0;
            Inicio = inicio;
            Fim = fim;
            Descricao = descricao;
        }
    }
}
