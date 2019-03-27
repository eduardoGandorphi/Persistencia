using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.View
{
    public class Menu_PG
    {
        public void Abrir()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("================================= Menu =================================");
                Console.WriteLine("Opções: [1] Pessoas    [2] Professores    [3] Aluno    [0] Sair");
                var input = int.Parse(Console.ReadLine());

                if (input == 0)
                    continuar = false;

                else if (input == 1)
                {
                    var pessoa_pg = new Pessoa_PG();
                    pessoa_pg.Abrir();
                }
                else if (input == 2)
                {
                    var professor_PG = new Professor_PG();
                    professor_PG.Abrir();
                }
            }
        }
    }
}
