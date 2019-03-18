using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlite.Model
{
    public class Pessoa
    {
        [PrimaryKey,AutoIncrement,NotNull]        
        public int PessoaId { get; set; }

        [NotNull]
        public string Nome{ get; set; }

        [NotNull]
        public int Telefone{ get; set; }

        [NotNull]
        public DateTime DataNacimento{ get; set; }
    }
}
