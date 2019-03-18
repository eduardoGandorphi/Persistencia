using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlite.Model
{
    public class Professor
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int ProfessorId { get; set; }

        [NotNull]
        public decimal Salario { get; set; }



        [NotNull]
        public int PessoaId { get; set; }
    }
}
