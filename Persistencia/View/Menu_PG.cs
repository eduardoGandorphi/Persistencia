using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.View
{
    public class Menu_PG
    {
        public static void Abrir()
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
                    (new Pessoa_PG()).Abrir();
            }
        }
    }
}
