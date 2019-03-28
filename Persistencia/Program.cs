using ConsoleSqlite.DataAccess;
using ConsoleSqlite.Model;
using Persistencia.View;
using Persistencia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Conexao.CriaBanco();

            var menu = new Menu_PG();
            menu.Abrir();

            //var teste = new Cadastro_VM();
            //teste.CadastroCompleto(new Pessoa_MD { Nome = "exception", DataNacimento = new DateTime(1991, 03, 13), Telefone = 81818181 }
            //                      , new Professor_MD { PessoaId = 1, Salario = 1000 });
        }
    }
}
