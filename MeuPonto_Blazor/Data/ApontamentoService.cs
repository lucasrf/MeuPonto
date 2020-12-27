using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPonto;

namespace MeuPonto_Blazor.Data
{
    public class ApontamentoService
    {
        public Task<PontoExibicao[]> GetApontamentos(Funcionario funcionario, Periodo periodo)
        {
            List<Ponto> listaPonto = funcionario.GetPontosByPeriodo(periodo);
            List<PontoExibicao> exibicao = new List<PontoExibicao>();

            foreach (Ponto ponto in listaPonto)
            {
                exibicao.Add(ponto.ToPontoExibicao());
            }

            return Task.FromResult(exibicao.ToArray());
        }
    }
}