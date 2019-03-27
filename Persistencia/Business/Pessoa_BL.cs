using ConsoleSqlite.Model;
using Persistencia.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Business
{
    //CAMADA DE NEGÓCIO, LÓGICA
    public class Pessoa_BL
    {
        public Pessoa_DA da = new Pessoa_DA();


        //chama o acesso a dados que Insere os valores de md no banco
        public void Create(Pessoa_MD md)
        {
            ValidarDados(md);
            da.Create(md);
        }

        //chama o acesso a dados que Obtem as informações da pessoa do id informado
        public Pessoa_MD Read(int id)
        {
            if (id == 0)
                throw new Exception("O id não pode ser 0.");

            return da.Read(id);
        }

        //chama o acesso a dados que Atualiza as informações de uma pessoa baseado no id dentro do md
        public void Update(Pessoa_MD md)
        {
            ValidarIdentificacao(md);
            ValidarDados(md);
            da.Update(md);
        }

        //chama o acesso a dados que apaga as informações de uma passeoa baseado id do md
        public void Delete(Pessoa_MD md)
        {
            ValidarIdentificacao(md);
            da.Delete(md);
        }

        //chama o acesso a dados que tras a lista de possoas todas
        public List<Pessoa_MD> List()
        {
            return da.List();
        }


        //metodo de validação do id
        public void ValidarIdentificacao(Pessoa_MD md)
        {
            if(md == null)
                throw new Exception("O md não pode ser nulo.");

            if (md.PessoaId == 0)
                throw new Exception("O md não pode ter o id 0.");
        }


        //metodos de validação dos dados restantes
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
