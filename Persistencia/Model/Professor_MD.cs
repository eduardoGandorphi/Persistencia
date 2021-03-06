﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlite.Model
{
    public class Professor_MD
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int ProfessorId { get; set; }

        [NotNull]
        public decimal Salario { get; set; }



        [NotNull]
        public int PessoaId { get; set; }

        [SQLite.Ignore]
        public string PessoaNome { get; set; }

        public override string ToString()
        {
            return $"[{ProfessorId}]\t[{PessoaId}]\t\t{Salario}\t{PessoaNome}";
        }
    }
}
