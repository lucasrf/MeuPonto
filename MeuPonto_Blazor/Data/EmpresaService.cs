using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuPonto_Blazor;

namespace MeuPonto_Blazor.Data
{
    public class EmpresaService : Empresa
    {
        private readonly ApplicationDbContext _db;

        public EmpresaService(ApplicationDbContext db)
        {
            Empresa empresa = new Empresa();

            Populate(empresa);

            _db = db;

            _db.Empresas.Add(empresa);
            _db.SaveChanges();
        }
        public void Populate(Empresa _empresa)
        {
            _empresa.Funcionarios.Add(new Funcionario("Jorge Marques", 0));
            _empresa.Funcionarios.Add(new Funcionario("Iolanda da Silva ", 1));
            _empresa.Funcionarios.Add(new Funcionario("Roberto Panamero", 3));

            _empresa.AbrirPeriodo(new DateTime(2021, 1, 1));
            _empresa.AbrirPeriodo(new DateTime(2020, 12, 1));
            _empresa.AbrirPeriodo(new DateTime(2020, 11, 1));
            _empresa.AbrirPeriodo(new DateTime(2020, 10, 1));

            _empresa.Funcionarios.First().Pontos[0].Marcacoes.Add(new Marcacao(new TimeSpan(08, 00, 00), new TimeSpan(12, 00, 00)));
            _empresa.Funcionarios.First().Pontos[0].Marcacoes.Add(new Marcacao(new TimeSpan(13, 00, 00), new TimeSpan(18, 00, 00)));
            _empresa.Funcionarios.First().Pontos[1].Marcacoes.Add(new Marcacao(new TimeSpan(07, 00, 00), new TimeSpan(12, 00, 00)));
            _empresa.Funcionarios.First().Pontos[1].Marcacoes.Add(new Marcacao(new TimeSpan(13, 00, 00), new TimeSpan(17, 00, 00)));
        }

        public Empresa GetEmpresa()
        {
            return _db.Empresas.First();
        }
    }
}
