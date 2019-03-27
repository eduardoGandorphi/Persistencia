using ConsoleSqlite.Model;
using Persistencia.Business;
using Persistencia.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.View
{
    public class Professor_PG
    {

        Professor_BL bl = new Professor_BL();
        public void Abrir()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("================================= Professores =================================");
                Console.WriteLine("\tId\tidPessoa\tSalario");
                
                foreach (var item in bl.List())
                    Console.WriteLine("\t"+item);

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Opções:");
                Console.WriteLine("\t[1] Create    [2]Read    [3] Update    [4] Delete    [0] Sair");
                var input = int.Parse(Console.ReadLine());



                if (input == 0)
                    continuar = false;

                else
                    Detalhe(input);
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

        public void Create()
        {
            Console.WriteLine("============ Create Professor ============");

            Console.WriteLine("Informe o id da pessoa que sera usado para o professor:");
            var pessoaIdEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o novo salario:");
            var salarioEntrada = decimal.Parse(Console.ReadLine());


            var md = new Professor_MD()
            {
                PessoaId = pessoaIdEntrada,
                Salario = salarioEntrada,
            };
            
            bl.Create(md);
        }

        public void Read()
        {
            Console.WriteLine("============ Read Professor ============");

            Console.WriteLine("Informe id:");
            var idEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Registro " + idEntrada);
            var mdLido = bl.Read(idEntrada);
            Console.WriteLine(mdLido);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(Values.PressioneQualquerTecla);
            Console.ReadKey();


        }

        public void Update()
        {
            Console.WriteLine("============ Update Professor ============");

            Console.WriteLine("Informe id:");
            var idEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Registro " + idEntrada);
            var mdLido = bl.Read(idEntrada);
            Console.WriteLine(mdLido);


            Console.WriteLine("Informe o id da pessoa que sera usado para o professor:");
            var pessoaIdEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o novo salario:");
            var salarioEntrada = decimal.Parse(Console.ReadLine());
            

            var md = new Professor_MD()
            {
                ProfessorId = idEntrada,
                PessoaId = pessoaIdEntrada,
                Salario = salarioEntrada,                
            };
            bl.Update(md);
        }

        public void Delete()
        {
            Console.WriteLine("============ Delete Professor ============");

            Console.WriteLine("Informe id:");
            var idEntrada = int.Parse(Console.ReadLine());

            bl.Delete(new Professor_MD { ProfessorId = idEntrada });
        }

    }
}
