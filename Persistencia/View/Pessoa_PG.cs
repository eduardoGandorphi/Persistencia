using Persistencia.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.View
{
    public class Pessoa_PG
    {
        public static void Abrir()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("================================= Pessoas =================================");
                Console.WriteLine(" [0] Sair");

                var bl = new Pessoa_BL();
                foreach (var item in bl.List())
                    Console.WriteLine(item);


                var input = int.Parse(Console.ReadLine());

                if (input == 0)
                    continuar = false;                
            }
        }
    }
}
