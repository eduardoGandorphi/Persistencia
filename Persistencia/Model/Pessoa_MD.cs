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
        [PrimaryKey,AutoIncrement,NotNull]        
        public int PessoaId { get; set; }

        [NotNull]
        public string Nome{ get; set; }

        [NotNull]
        public int Telefone{ get; set; }

        [NotNull]
        public DateTime DataNacimento{ get; set; }

        public override string ToString()
        {
            return $"\t[{PessoaId}]\t{DataNacimento.ToString("dd/MM/yyyy")}\t{Nome}";
        }
    }
}
