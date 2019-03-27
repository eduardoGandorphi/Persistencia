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
    //ATENÇÃO: Classe que simula o comportamento de uma tela.
    public class Pessoa_PG
    {

        Pessoa_BL bl = new Pessoa_BL();

        //metodo que sera chamado quando a 'tela' for abrir, ele quem desenha a tela.
        public void Abrir()
        {
            bool continuar = true;

            //loop para conseguir executar varias funções.
            while (continuar)
            {
                //limpa a tela
                Console.Clear();

                //escreve o cabeçalho
                Console.WriteLine("================================= Pessoas =================================");                
                Console.WriteLine("\tId\tNascimento\tNome");

                //Busca lista de pessoas no banco
                var listaPessoas = bl.List();

                //loop em cada pessoa da lista
                foreach (var pessoa in listaPessoas)
                    Console.WriteLine("\t" + pessoa);// vai escrever o que esta dentro do ToString() da classe Pessoa_MD

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Opções:");
                Console.WriteLine("\t[1] Create    [2]Read    [3] Update    [4] Delete    [0] Sair");

                //Recebe input do usuario
                var input = int.Parse(Console.ReadLine());


                // sai da tela caso o usuario inputou 0;
                if (input == 0)
                    continuar = false;
                
                //verifica com função o usuario digitou
                else
                    Detalhe(input);
            }
        }


        public void Detalhe(int opcao)
        {
            //deixa o código em alerta para exceptions
            try
            {
                //limpa a tela
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
            //vem pra ca caso alguma exception aconteça
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Console.WriteLine("\n\n");
                Console.WriteLine(Values.PressioneQualquerTecla);
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
            Console.WriteLine(Values.PressioneQualquerTecla);
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
