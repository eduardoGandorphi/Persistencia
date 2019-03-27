using ConsoleSqlite.DataAccess;
using ConsoleSqlite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DataAccess
{
    //CAMADA DE ACESSO A DADOS
    public class Pessoa_DA
    {
        //Insere os valores de md no banco
        public void Create(Pessoa_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Insert(md);
            db.Commit();
            db.Close();
        }

        //Obtem as informações da pessoa do id informado
        public Pessoa_MD Read(int id)
        {
            var db = Conexao.GetConn();

            return db.Table<Pessoa_MD>()
                .Where(p => p.PessoaId == id)
                .FirstOrDefault();
        }

        //Atualiza as informações de uma pessoa baseado no id dentro do md
        public void Update(Pessoa_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Update(md);
            db.Commit();
            db.Close();
        }

        //apaga as informações de uma passeoa baseado id do md
        public void Delete(Pessoa_MD md)
        {
            var db = Conexao.GetConn();
            db.BeginTransaction();
            db.Delete(md);
            db.Commit();
            db.Close();
        }

        //tras a lista de possoas todas
        public List<Pessoa_MD> List(Func<Pessoa_MD,bool> where =  null)
        {
            var db = Conexao.GetConn();
            
            return db.Table<Pessoa_MD>()
                .Where(where)
                .ToList();
        }
    }
}
