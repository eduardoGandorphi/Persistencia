using ConsoleSqlite.DataAccess;
using ConsoleSqlite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DataAccess
{
    public class Professor_DA
    {

        public void Create(Professor_MD md, SQLiteConnection db = null)
        {
            bool commit = (db == null);

            if (db == null)
                db = Conexao.GetConn();


            if (commit)
            {
                db.BeginTransaction();
                db.Insert(md);
                db.Commit();
                db.Close();
            }
            else
                db.Insert(md);
        }

        public Professor_MD Read(int id, SQLiteConnection db = null)
        {
            if (db == null)
                db = Conexao.GetConn();

            return db.Table<Professor_MD>()
                .Where(p => p.ProfessorId == id)
                .FirstOrDefault();
        }

        public void Update(Professor_MD md, SQLiteConnection db = null)
        {
            bool commit = (db == null);

            if (db == null)
                db = Conexao.GetConn();


            if (commit)
            {
                db.BeginTransaction();
                db.Update(md);
                db.Commit();
                db.Close();
            }
            else
                db.Update(md);
        }

        public void Delete(Professor_MD md, SQLiteConnection db = null)
        {
            bool commit = (db == null);

            if (db == null)
                db = Conexao.GetConn();

            if (commit)
            {
                db.BeginTransaction();
                db.Delete(md);
                db.Commit();
                db.Close();
            }
            else
                db.Delete(md);
        }

        public List<Professor_MD> List(SQLiteConnection db = null)
        {
            if (db == null)
                db = Conexao.GetConn();

            return db.Table<Professor_MD>()
                .ToList();
        }
    }
}
