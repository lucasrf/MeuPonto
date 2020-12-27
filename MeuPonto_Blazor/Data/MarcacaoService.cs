using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPonto;

namespace MeuPonto_Blazor.Data
{
    public class MarcacaoService
    {
        public Task<Marcacao[]> GetMarcacoes(Ponto ponto) => Task.FromResult(ponto.Marcacoes.ToArray());
    }
}
