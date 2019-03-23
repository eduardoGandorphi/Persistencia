using ConsoleSqlite.Model;
using Persistencia.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Business
{
    public class Pessoa_BL
    {
        public Pessoa_DA da = new Pessoa_DA();


        public void Create(Pessoa_MD md)
        {
            ValidarDados(md);
            da.Create(md);
        }

        public Pessoa_MD Read(int id)
        {
            if (id == 0)
                throw new Exception("O id não pode ser 0.");

            return da.Read(id);
        }

        public void Update(Pessoa_MD md)
        {
            ValidarIdentificacao(md);
            ValidarDados(md);
            da.Update(md);
        }

        public void Delete(Pessoa_MD md)
        {
            ValidarIdentificacao(md);
            da.Delete(md);
        }

        public List<Pessoa_MD> List()
        {
            return da.List();
        }

        public void ValidarIdentificacao(Pessoa_MD md)
        {
            if(md == null)
                throw new Exception("O md não pode ser nulo.");

            if (md.PessoaId == 0)
                throw new Exception("O md não pode ter o id 0.");
        }

        public void ValidarDados(Pessoa_MD md)
        {
            if (md.Nome == null)
                throw new Exception("O nome não pode ser nulo");

            if (md.Telefone < 1000000)
                throw new Exception("O numero muito pequeno.");

            if (md.DataNacimento == null)
                throw new Exception("O nascimento não pode ser vazio.");

            if (md.DataNacimento < new DateTime(1900,01,01))
                throw new Exception("O nascimento não pode ser tão pequeno.");
        }

    }
}
