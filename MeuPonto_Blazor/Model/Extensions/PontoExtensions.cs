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

            if (ponto.GetJornada() >= EmpresaService.JornadaDiaria - new TimeSpan(00, 10, 00))
            {
                resultado += "Horas normais: 08:45:00 \n";

                if (ponto.GetJornada() >= EmpresaService.JornadaDiaria + new TimeSpan(00, 10, 00))
                {
                    resultado += "Horas extras: " + (ponto.GetJornada() - EmpresaService.JornadaDiaria) + "\n";
                }
            }
            else
            {
                resultado += "Horas normais: " + ponto.GetJornada() + "\n";
                resultado += "Horas atraso: " + (EmpresaService.JornadaDiaria - ponto.GetJornada());
            }
            return resultado;
        }
    }
}
