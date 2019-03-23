using ConsoleSqlite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlite.DataAccess
{
    public class Conexao
    {
        public static string dbPath = @"C:\Temp\tess.db";


        public static SQLiteConnection GetConn(bool storeDateTimeAsTicks = false)
        {
            return new SQLiteConnection(dbPath, storeDateTimeAsTicks: storeDateTimeAsTicks);
        }
        public static void CriaBanco(bool storeDateTimeAsTicks = false)
        {
            var db = GetConn();

            CriaTabelasCodeFirst(db);
            popularComModels(db);
        }


        private static void CriaTabelasCodeFirst(SQLiteConnection db)
        {
            //CRIA TABELA DE PESSOA
            db.CreateTable<Pessoa>();

            //CRIA TABELA DE PROFESSOR
            db.CreateTable<Professor>();

            //CRIA TABELA DE ALUNO
            db.CreateTable<Aluno>();
        }

        


        //INSERTS
        private static void popularComModels(SQLiteConnection db)
        {
            db.BeginTransaction();
            //PESSOA
            Pessoa pessoa1 = new Pessoa { Nome = "Eduardo", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234567 };
            db.Insert(pessoa1);

            Pessoa pessoa2 = new Pessoa { Nome = "Diogo", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234568 };
            db.Insert(pessoa2);

            Pessoa pessoa3 = new Pessoa { Nome = "Jefferson", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234569 };
            db.Insert(pessoa3);

            Pessoa pessoa4 = new Pessoa { Nome = "Leandro", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234569 };
            db.Insert(pessoa4);

            db.Commit();
            db.Close();
        }











        ////OPCIONAL, use OU o popularComModels OU CriaTabelasDbFirst
        //private static void CriaTabelasDbFirst(SQLiteConnection db)
        //{
        //    //CRIA TABELA DE PESSOA
        //    db.Execute(@"CREATE TABLE 'Pessoa' (
        //                    'PessoaId'  integer NOT NULL PRIMARY KEY AUTOINCREMENT,
        //                    'Nome'  varchar NOT NULL,
        //                    'Telefone'  integer NOT NULL,
        //                    'DataNacimento' text NOT NULL
        //                );");

        //    //CRIA TABELA DE PROFESSOR
        //    db.Execute(@"CREATE TABLE 'Professor' (
        //                    'ProfessorId'   integer NOT NULL PRIMARY KEY AUTOINCREMENT,
        //                    'Salario'   float NOT NULL,
        //                    'PessoaId'  integer NOT NULL
        //                ); ");

        //    //CRIA TABELA DE ALUNO
        //    db.Execute(@"CREATE TABLE 'Aluno' (
        //                    'AlunoId'   integer NOT NULL PRIMARY KEY AUTOINCREMENT,
        //                    'Mensalidade'   float NOT NULL,
        //                    'PessoaId'  integer NOT NULL
        //                ); ");
        //}

        ////INSERTS com Comandos, OPCIONAL, use OU o popularComModels OU popularComExecute
        //private static void popularComExecute(SQLiteConnection db)
        //{
        //    db.BeginTransaction();
        //    //CRIA TABELA DE ALUNO
        //    db.Execute(@"INSERT INTO 'Pessoa'('Nome','DataNacimento','Telefone') VALUES('Eduardo','1991-03-13T00:00:00.000','981234567');");
        //    db.Execute(@"INSERT INTO 'Pessoa'('Nome','DataNacimento','Telefone') VALUES('Diogo','1991-03-13T00:00:00.000','981234568'); ");
        //    db.Execute(@"INSERT INTO 'Pessoa'('Nome','DataNacimento','Telefone') VALUES('Jefferson','1991-03-13T00:00:00.000','981234569');");
        //    db.Execute(@"INSERT INTO 'Pessoa'('Nome','DataNacimento','Telefone') VALUES('Leandro','1991-03-13T00:00:00.000','981234569');");

        //    db.Commit();
        //    db.Close();
        //}
    }
}
