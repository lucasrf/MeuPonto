using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPonto;

namespace MeuPonto_Blazor.Data
{
    public class EmpresaService : Empresa
    {
        private static Empresa _empresa;

        public EmpresaService()
        {
            _empresa = new Empresa();
            Populate();
        }
        public Empresa GetEmpresa()
        {
            return _empresa;
        }
        public void Populate()
        {
            _empresa.Funcionarios.Add(new Funcionario("Jorge Marques", 0));
            _empresa.Funcionarios.Add(new Funcionario("Iolanda da Silva ", 1));
            _empresa.Funcionarios.Add(new Funcionario("Roberto Panamero", 3));

            _empresa.AbrirPeriodo(new DateTime(2021, 1, 1));
            _empresa.AbrirPeriodo(new DateTime(2020, 12, 1));
            _empresa.AbrirPeriodo(new DateTime(2020, 11, 1));
            _empresa.AbrirPeriodo(new DateTime(2020, 10, 1));

            _empresa.Funcionarios.First().Pontos[0].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 08, 00, 00), new DateTime(2020, 12, 01, 12, 00, 00)));
            _empresa.Funcionarios.First().Pontos[0].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 13, 00, 00), new DateTime(2020, 12, 01, 18, 00, 00)));
            _empresa.Funcionarios.First().Pontos[1].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 07, 00, 00), new DateTime(2020, 12, 01, 12, 00, 00)));
            _empresa.Funcionarios.First().Pontos[1].Marcacoes.Add(new Marcacao(new DateTime(2020, 12, 01, 13, 00, 00), new DateTime(2020, 12, 01, 17, 00, 00)));
        }
    }
}
