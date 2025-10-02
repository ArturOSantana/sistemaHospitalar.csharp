// See https://aka.ms/new-console-template for more information

namespace Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BEM VINDO AO SISTEMA HOSPITALAR");
            Paciente[] filaPreferencial = new Paciente[15];
            Paciente[] filaNormal = new Paciente[15];
            string opcao;
            int qtdPreferencial = 0;
            int qtdNormal = 0;



            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine(" 1 - Cadastrar Paciente");
                Console.WriteLine(" 2 - Listar Pacientes");
                Console.WriteLine(" 3 - Atender Pacientes ");
                Console.WriteLine(" 4 - Alterar Dados");
                Console.WriteLine(" Q - sair");
                opcao = Console.ReadLine();


                switch (opcao)
                {
                    case "1":
                        cadastrarPaciente();
                        break;
                    case "2":
                        mostrarPacientes();
                        break;
                    case "3":
                        cadastrarPaciente();
                        break;
                    case "4":
                        cadastrarPaciente();
                        break;
                    case "q":
                        break;
                    case "Q":
                        break;

                }
            } while (opcao != "q");


            void cadastrarPaciente()
            {

                Paciente p = new Paciente();
                Console.WriteLine("Nome:");
                p.nome = Console.ReadLine();

                Console.WriteLine("Idade:");
                p.idade = int.Parse(Console.ReadLine());

                Console.WriteLine("CPF:");
                p.cpf = Console.ReadLine();

                Console.WriteLine("É preferencial? S/N");
                string aux = Console.ReadLine();
                if (aux == "s" || aux == "S")
                {
                    p.prioridade = true;
                }
                else
                {
                    p.prioridade = false;
                }

                // Adicionando ele a fila 
                if (p.prioridade == true)
                {
                    filaPreferencial[qtdPreferencial] = p;
                    qtdPreferencial++;
                }
                else
                {
                    filaNormal[qtdNormal] = p;
                    qtdPreferencial++;
                }



                    Console.WriteLine(p.nome + " Paciente Cadastrado com Sucesso");
            }

            void mostrarPacientes()
            {

                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine(filaPreferencial[i]);
                    Console.WriteLine(filaNormal[i]);
                    }
                
            }
        }
    }
}
