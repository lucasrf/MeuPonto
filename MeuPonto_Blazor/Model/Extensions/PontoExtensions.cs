using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPonto_Blazor.Data;

namespace MeuPonto
{
    public static class PontoExtensions
    {
        public static string GetMarcacoes(this Ponto ponto)
        {
            string marcacoesToString = "| ";

            foreach (Marcacao marcacao in ponto.Marcacoes)
            {
                marcacoesToString += marcacao.Inicio.ToShortTimeString() + " | " + marcacao.Fim.ToShortTimeString() + " |";
            }

            return marcacoesToString;
        }
        public static TimeSpan GetJornada(this Ponto ponto)
        {
            TimeSpan somaMarcacoes = TimeSpan.Zero;

            foreach (Marcacao marcacao in ponto.Marcacoes)
            {
                somaMarcacoes += marcacao.GetIntervalo();
            }

            return somaMarcacoes;
        }

        public static PontoExibicao ToPontoExibicao(this Ponto ponto) => new PontoExibicao
        {
            Date = ponto.Date.ToShortDateString(),
            Marcacao = ponto.GetMarcacoes(),
            Jornada = ponto.GetJornada().ToString(),
            Observacao = ponto.Observacao
        };
    }
}
