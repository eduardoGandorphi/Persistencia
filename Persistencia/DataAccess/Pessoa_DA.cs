using ConsoleSqlite.DataAccess;
using ConsoleSqlite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DataAccess
{
    public class Pessoa_DA
    {

        public void Create(Pessoa_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Insert(md);
            db.Commit();
            db.Close();
        }

        public Pessoa_MD Read(int id)
        {
            var db = Conexao.GetConn();

            return db.Table<Pessoa_MD>()
                .Where(p => p.PessoaId == id)
                .FirstOrDefault();
        }

        public void Update(Pessoa_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Update(md);
            db.Commit();
            db.Close();
        }

        public void Delete(int id)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Delete(id);
            db.Commit();
            db.Close();
        }

        public List<Pessoa_MD> List()
        {
            var db = Conexao.GetConn();

            return db.Table<Pessoa_MD>()
                .ToList();
        }
    }
}
