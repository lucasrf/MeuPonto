using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPonto_Blazor.Data;

namespace MeuPonto_Blazor
{
    public static class PontoExtensions
    {
        public static string GetMarcacoes(this Ponto ponto)
        {
            string marcacoesToString = "| ";

            foreach (Marcacao marcacao in ponto.Marcacoes)
            {
                marcacoesToString += marcacao.Inicio + " | " + marcacao.Fim + " |";
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
        public static string GetDescricaoJornada(this Ponto ponto)
        {
            string resultado = "";

            if (ponto.GetJornada() >= MainService.JornadaDiaria - new TimeSpan(00, 10, 00))
            {
                resultado += "Horas normais: 08:45:00 \n";

                if (ponto.GetJornada() >= MainService.JornadaDiaria + new TimeSpan(00, 10, 00))
                {
                    resultado += "Horas extras: " + (ponto.GetJornada() - MainService.JornadaDiaria) + "\n";
                }
            }
            else
            {
                resultado += "Horas normais: " + ponto.GetJornada() + "\n";
                resultado += "Horas atraso: " + (MainService.JornadaDiaria - ponto.GetJornada());
            }
            return resultado;
        }
    }
}
