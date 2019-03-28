using ConsoleSqlite.DataAccess;
using ConsoleSqlite.Model;
using Persistencia.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ViewModel
{
    public class Cadastro_VM
    {
        Pessoa_BL pessoa_BL = new Pessoa_BL();
        Professor_BL professor_BL = new Professor_BL();

        public void CadastroCompleto(Pessoa_MD pessoaMd, Professor_MD professorMd)
        {
            var db = Conexao.GetConn();

            db.BeginTransaction();
           
            try
            {
                pessoa_BL.Create(pessoaMd, db);
                professor_BL.Create(professorMd, db);                
                db.Commit();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
            }            
            db.Close();

        }
    }
}
