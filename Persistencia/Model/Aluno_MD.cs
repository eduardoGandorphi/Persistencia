using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlite.Model
{
    public class Aluno_MD
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int AlunoId { get; set; }

        [NotNull]
        public decimal Mensalidade { get; set; }


        [NotNull]
        public int PessoaId { get; set; }
    }
}
