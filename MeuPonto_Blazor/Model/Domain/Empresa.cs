﻿using System;
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
