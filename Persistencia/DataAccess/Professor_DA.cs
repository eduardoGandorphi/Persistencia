using ConsoleSqlite.DataAccess;
using ConsoleSqlite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DataAccess
{
    public class Professor_DA
    {

        public void Create(Professor_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Insert(md);
            db.Commit();
            db.Close();
        }

        public Professor_MD Read(int id)
        {
            var db = Conexao.GetConn();

            return db.Table<Professor_MD>()
                .Where(p => p.ProfessorId == id)
                .FirstOrDefault();
        }

        public void Update(Professor_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Update(md);
            db.Commit();
            db.Close();
        }

        public void Delete(Professor_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Delete(md);
            db.Commit();
            db.Close();
        }

        public List<Professor_MD> List()
        {
            var db = Conexao.GetConn();

            return db.Table<Professor_MD>()
                .ToList();
        }
    }
}
