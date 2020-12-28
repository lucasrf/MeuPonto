using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPonto;

namespace MeuPonto_Blazor.Data
{
    public class ApontamentoService
    {
        public Task<Ponto[]> GetApontamentos(Funcionario funcionario, Periodo periodo) => 
            Task.FromResult(funcionario.GetPontosByPeriodo(periodo).ToArray());
    }
}