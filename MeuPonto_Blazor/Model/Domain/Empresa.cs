using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Empresa
    {
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public List<Periodo> Periodos { get; set; } = new List<Periodo>();
        public Empresa()
        {
            Populate();
        }
        public void Populate()
        {
            Funcionarios.Add(new Funcionario("Joao da Silva"));

            AbrirPeriodo(new DateTime(2020, 12, 1));

            Funcionarios.First().Pontos[0].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 08, 00, 00), new DateTime(2020, 12, 01, 12, 00, 00)));
            Funcionarios.First().Pontos[0].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 13, 00, 00), new DateTime(2020, 12, 01, 18, 00, 00)));

            Funcionarios.First().Pontos[1].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 07, 00, 00), new DateTime(2020, 12, 01, 12, 00, 00)));
            Funcionarios.First().Pontos[1].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 13, 00, 00), new DateTime(2020, 12, 01, 17, 00, 00)));
        }
        public void AbrirPeriodo(DateTime periodo)
        {
            foreach (DateTime date in GetDatesInMonth(periodo.Year, periodo.Month))
            {
                foreach (Funcionario funcionario in Funcionarios)
                {
                    funcionario.Pontos.Add(new Ponto(date));
                }
            }
            Periodos.Add(new Periodo(periodo));
        }
        public static IEnumerable<DateTime> GetDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
    }
}
