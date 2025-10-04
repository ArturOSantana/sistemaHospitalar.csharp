// See https://aka.ms/new-console-template for more information

namespace Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BEM VINDO AO SISTEMA HOSPITALAR");
            Paciente[] fila = new Paciente[15];

            string opcao;
            int qtdfila = 0;





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
                    int posicao = 0;
                    while (posicao < qtdfila && fila[posicao].prioridade == true)
                    {
                        posicao++;
                    }
                    for (int con = qtdfila; con > posicao; con--)
                    {
                        fila[con] = fila[con - 1];
                    }


                    fila[posicao] = p;
                }
                else
                {
                    fila[qtdfila] = p;
                }
                qtdfila++;

                Console.WriteLine(fila[1]);



                Console.WriteLine(p.nome + " Paciente Cadastrado com Sucesso");

            }
            void mostrarPacientes()
            {

                for (int i = 0; i < qtdfila; i++)
                {
                    Console.WriteLine($"{fila[i].nome}, Idade: {fila[i].idade} CPF: {fila[i].cpf}");
                    if (fila[i].prioridade == true)
                    {
                        Console.Write("É Preferencial");
                    }
                    else
                    {
                        Console.WriteLine("Não é Preferencial");
                    }
                }
            }
            void atenderpaciente()
            { 
                if (qtdfila == 0)
                {
                    Console.Write("FILA VAZIA");
                }

            }
        }
    }
}
