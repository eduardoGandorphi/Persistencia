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
            //popularComModels(db);
        }


        private static void CriaTabelasCodeFirst(SQLiteConnection db)
        {
            //CRIA TABELA DE Pessoa_MD
            db.CreateTable<Pessoa_MD>();

            //CRIA TABELA DE PROFESSOR
            db.CreateTable<Professor_MD>();

            //CRIA TABELA DE ALUNO
            db.CreateTable<Aluno_MD>();
        }

        


        //INSERTS
        private static void popularComModels(SQLiteConnection db)
        {
            db.BeginTransaction();
            //Pessoa_MD
            Pessoa_MD Pessoa_MD1 = new Pessoa_MD { Nome = "Eduardo", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234567 };
            db.Insert(Pessoa_MD1);

            Pessoa_MD Pessoa_MD2 = new Pessoa_MD { Nome = "Diogo", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234568 };
            db.Insert(Pessoa_MD2);

            Pessoa_MD Pessoa_MD3 = new Pessoa_MD { Nome = "Jefferson", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234569 };
            db.Insert(Pessoa_MD3);

            Pessoa_MD Pessoa_MD4 = new Pessoa_MD { Nome = "Leandro", DataNacimento = new DateTime(1991, 3, 13), Telefone = 981234569 };
            db.Insert(Pessoa_MD4);

            db.Commit();
            db.Close();
        }











        ////OPCIONAL, use OU o popularComModels OU CriaTabelasDbFirst
        //private static void CriaTabelasDbFirst(SQLiteConnection db)
        //{
        //    //CRIA TABELA DE Pessoa_MD
        //    db.Execute(@"CREATE TABLE 'Pessoa_MD' (
        //                    'Pessoa_MDId'  integer NOT NULL PRIMARY KEY AUTOINCREMENT,
        //                    'Nome'  varchar NOT NULL,
        //                    'Telefone'  integer NOT NULL,
        //                    'DataNacimento' text NOT NULL
        //                );");

        //    //CRIA TABELA DE PROFESSOR
        //    db.Execute(@"CREATE TABLE 'Professor' (
        //                    'ProfessorId'   integer NOT NULL PRIMARY KEY AUTOINCREMENT,
        //                    'Salario'   float NOT NULL,
        //                    'Pessoa_MDId'  integer NOT NULL
        //                ); ");

        //    //CRIA TABELA DE ALUNO
        //    db.Execute(@"CREATE TABLE 'Aluno' (
        //                    'AlunoId'   integer NOT NULL PRIMARY KEY AUTOINCREMENT,
        //                    'Mensalidade'   float NOT NULL,
        //                    'Pessoa_MDId'  integer NOT NULL
        //                ); ");
        //}

        ////INSERTS com Comandos, OPCIONAL, use OU o popularComModels OU popularComExecute
        //private static void popularComExecute(SQLiteConnection db)
        //{
        //    db.BeginTransaction();
        //    //CRIA TABELA DE ALUNO
        //    db.Execute(@"INSERT INTO 'Pessoa_MD'('Nome','DataNacimento','Telefone') VALUES('Eduardo','1991-03-13T00:00:00.000','981234567');");
        //    db.Execute(@"INSERT INTO 'Pessoa_MD'('Nome','DataNacimento','Telefone') VALUES('Diogo','1991-03-13T00:00:00.000','981234568'); ");
        //    db.Execute(@"INSERT INTO 'Pessoa_MD'('Nome','DataNacimento','Telefone') VALUES('Jefferson','1991-03-13T00:00:00.000','981234569');");
        //    db.Execute(@"INSERT INTO 'Pessoa_MD'('Nome','DataNacimento','Telefone') VALUES('Leandro','1991-03-13T00:00:00.000','981234569');");

        //    db.Commit();
        //    db.Close();
        //}
    }
}
