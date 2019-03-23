using ConsoleSqlite.Model;
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

        Pessoa_BL bl = new Pessoa_BL();
        public void Abrir()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("================================= Pessoas =================================");                
                Console.WriteLine("\tId\tNascimento\tNome");

                var bl = new Pessoa_BL();
                foreach (var item in bl.List())
                    Console.WriteLine(item);

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
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void Create()
        {
            Console.WriteLine("============ Create Pessoa ============");

            Console.WriteLine("Informe o nome:");
            var nomeEntrada = Console.ReadLine();

            Console.WriteLine("Informe o telefone:");
            var telefoneEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o dia de nascimento:");
            var diaEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o mes de nascimento:");
            var mesEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o ano de nascimento:");
            var anoEntrada = int.Parse(Console.ReadLine());

            var md = new Pessoa_MD()
            {
                Nome = nomeEntrada,
                Telefone = telefoneEntrada,
                DataNacimento = new DateTime(anoEntrada, mesEntrada, diaEntrada)
            };

            bl.Create(md);
        }

        public void Read()
        {
            Console.WriteLine("============ Read Pessoa ============");

            Console.WriteLine("Informe id:");
            var idEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Registro " + idEntrada);
            var md = bl.Read(idEntrada);
            Console.WriteLine(md);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("pressione qualquer tecla para voltar.");
            Console.ReadKey();


        }

        public void Update()
        {
            Console.WriteLine("============ Update Pessoa ============");

            Console.WriteLine("Informe id:");
            var idEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Registro " + idEntrada);
            var mdLido = bl.Read(idEntrada);
            Console.WriteLine(mdLido);

            Console.WriteLine("Informe o novo nome:");
            var nomeEntrada = Console.ReadLine();

            Console.WriteLine("Informe o novo telefone:");
            var telefoneEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o novo dia de nascimento:");
            var diaEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o novo mes de nascimento:");
            var mesEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o novo ano de nascimento:");
            var anoEntrada = int.Parse(Console.ReadLine());

            var md = new Pessoa_MD()
            {
                PessoaId = idEntrada,
                Nome = nomeEntrada,
                Telefone = telefoneEntrada,
                DataNacimento = new DateTime(anoEntrada, mesEntrada, diaEntrada)
            };
            bl.Update(md);
        }

        public void Delete()
        {
            Console.WriteLine("============ Delete Pessoa ============");

            Console.WriteLine("Informe id:");
            var idEntrada = int.Parse(Console.ReadLine());
            
            bl.Delete(new Pessoa_MD { PessoaId = idEntrada});
        }

    }
}
