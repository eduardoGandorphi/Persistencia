using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlite.Model
{
    public class Pessoa_MD
    {
        //propriedade guarda a informação de Id
        [PrimaryKey,AutoIncrement,NotNull]        
        public int PessoaId { get; set; }

        [NotNull]
        public string Nome{ get; set; }

        [NotNull]
        public int Telefone{ get; set; }

        [NotNull]
        public DateTime DataNacimento{ get; set; }


        //Alteração da função padrão do ToString()
        //retorno exemplo: [3]  13/03/1991  Eduardo Freitas
        public override string ToString()
        {
            return $"[{PessoaId}]\t{DataNacimento.ToString("dd/MM/yyyy")}\t{Nome}";
        }
    }
}
//