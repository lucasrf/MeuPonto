using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto_Blazor.Data
{
    public class MainService
    {
        private static Empresa _empresa { get; set; }
        public static Periodo SelectedPeriodo { get; set; } //Periodo selecionado nas telas de apontamento e relatório
        public static Ponto SelectedPonto { get; set; } //Ponto selecionado na tela de apontamento
        public static TimeSpan JornadaDiaria { get { return new TimeSpan(08, 45, 00); } }

        public MainService()
        {
            SelectedPeriodo = new Periodo(DateTime.MinValue);
            SelectedPonto = new Ponto(DateTime.MinValue);
        }
        public Empresa GetEmpresa()
        {
            return _empresa;
        }

    }
}
