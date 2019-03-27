using Persistencia.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.View
{
    public class Materia_PG
    {

        public void Abrir()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                var input = int.Parse(Console.ReadLine());







                if (input == 0)
                    continuar = false;

            }
        }


        public void Detalhe(int opcao)
        {
            try
            {
                Console.Clear();

                if (opcao == 1)
                    Create();

                else if (opcao == 2)
                    Read();

                else if (opcao == 3)
                    Update();

                else if (opcao == 4)
                    Delete();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                Console.WriteLine("\n\n");
                Console.WriteLine(Values.PressioneQualquerTecla);
                Console.ReadKey();
            }
        }

        private void Create()
        {

        }
        private void Read()
        {

        }
        private void Update()
        {

        }
        private void Delete()
        {

        }
    }
}
