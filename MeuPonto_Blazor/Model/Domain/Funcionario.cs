﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuPonto
{
    public class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Ponto> Pontos { get; set; } = new List<Ponto>();

        public Funcionario(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public List<Ponto> GetPontosByPeriodo(Periodo periodo)
        {
            List<Ponto> pontos = new List<Ponto>();
            foreach (var ponto in Pontos)
            {
                if (ponto.Date >= periodo.Inicio && ponto.Date <= periodo.Fim)
                {
                    pontos.Add(ponto);
                }
            }
            return pontos;
        }
    }
}
