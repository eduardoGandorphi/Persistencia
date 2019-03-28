﻿using ConsoleSqlite.Model;
using Persistencia.DataAccess;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Business
{
    public class Professor_BL
    {
        Professor_DA da = new Professor_DA();


        public void Create(Professor_MD md, SQLiteConnection db = null)
        {
            ValidarDados(md);
            da.Create(md, db);
        }

        public Professor_MD Read(int id, SQLiteConnection db = null)
        {
            if (id == 0)
                throw new Exception("O id não pode ser 0.");

            return da.Read(id, db);
        }

        public void Update(Professor_MD md, SQLiteConnection db = null)
        {
            ValidarIdentificacao(md);
            ValidarDados(md);
            da.Update(md, db);
        }

        public void Delete(Professor_MD md, SQLiteConnection db = null)
        {
            ValidarIdentificacao(md);
            da.Delete(md, db);
        }

        public List<Professor_MD> List(SQLiteConnection db = null)
        {
            return da.List(db: db);
        }

        public void ValidarIdentificacao(Professor_MD md)
        {
            if (md == null)
                throw new Exception("O md não pode ser nulo.");

            if (md.ProfessorId == 0)
                throw new Exception("O md não pode ter o id 0.");
        }

        public void ValidarDados(Professor_MD md)
        {
            if (md.Salario <= 900)
                throw new Exception("O salario não pode ser menor que 900.");

            if (md.PessoaId == null || md.PessoaId == 0)
                throw new Exception("O id da pessoa precisa ser informado.");
        }

    }
}
