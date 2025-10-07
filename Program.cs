// See https://aka.ms/new-console-template for more information

using System.Net.NetworkInformation;

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
                        atenderpaciente();
                        break;
                    case "4":
                        alterarDados();
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("SAINDO");
                        break;

                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
            } while (opcao != "q" && opcao != "Q");


            void cadastrarPaciente()
            {
                if (qtdfila >= 15)
                {
                    Console.WriteLine("A fila está cheia");
                }
                else
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
                        for (int i = qtdfila; i > posicao; i--)
                        {
                            fila[i] = fila[i - 1];
                        }


                        fila[posicao] = p;
                    }
                    else
                    {
                        fila[qtdfila] = p;
                    }
                    qtdfila++;
                    Console.WriteLine($"QUANTIDADE DE PESSOAS NA FILA {qtdfila} ");

                    Console.WriteLine(fila[1]);



                    Console.WriteLine(p.nome + " Paciente Cadastrado com Sucesso\n");
                }
            }
            void mostrarPacientes()
            {
                if (qtdfila == 0)
                {
                    Console.WriteLine("A FILA ESTÁ VAZIA");
                }
               
                for (int i = 0; i < qtdfila; i++)
                {
                    string r;

                    if (fila[i].prioridade == true)
                    {

                        Console.WriteLine($" \n Codigo do Paciente: {i} - Nome: {fila[i].nome}, \nIdade: {fila[i].idade} \nCPF: {fila[i].cpf} \nÉ Prefencial? SIM");
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {

                        Console.WriteLine($"\n{fila[i].nome}\nIdade: {fila[i].idade}\nCPF: {fila[i].cpf}\nÉ Prefencial? NÃO");
                        Console.WriteLine("-------------------------");
                    }

                }
            }
            void atenderpaciente()
            {
                if (qtdfila == 0)
                {
                    Console.WriteLine("FILA VAZIA");

                }
                else
                {
                    Console.WriteLine($"Atendendo {fila[0].nome}");

                    for (int i = 0; qtdfila < i; i++)
                    {
                        fila[i] = fila[i + 1];
                    }
                    fila[qtdfila - 1] = null;
                    qtdfila--;
                }
            }

            void alterarDados()
                {
                    if (qtdfila == 0)
                    {
                        Console.WriteLine("FILA VAZIA");
                    }
                    else
                    {

                        Console.WriteLine("Digite o codigo do paciente");
                        int indice = int.Parse(Console.ReadLine());

                    if (indice >= qtdfila)
                    {
                        Console.WriteLine("Invalido");
                        }


                        Console.WriteLine($"O paciente selecionado foi: {fila[indice].nome}, Idade: {fila[indice].idade} CPF: {fila[indice].cpf} Preferencial: {fila[indice].prioridade}");

                        string alterador;
                        do
                        {
                            Console.WriteLine("Escolha uma opção:");
                            Console.WriteLine(" 1 - Alterar nome");
                            Console.WriteLine(" 2 - Alterar idade");
                            Console.WriteLine(" 3 - Alterar CPF ");
                            Console.WriteLine(" 4 - Aleterar Prioridade");
                            Console.WriteLine(" Q - sair");
                            alterador = Console.ReadLine();
                            switch (alterador)
                            {
                                case "1":
                                    Console.WriteLine("Digite o Nome:");
                                    fila[indice].nome = Console.ReadLine();
                                    break;
                                case "2":
                                    Console.WriteLine("Digite a Idade:");
                                    fila[indice].idade = int.Parse(Console.ReadLine());
                                    break;
                                case "3":
                                    Console.WriteLine("Digite o CPF:");
                                    fila[indice].cpf = Console.ReadLine();
                                    break;
                                case "4":
                                    Console.WriteLine("É preferencial ?");
                                    string resposta = Console.ReadLine();
                                
                                    break;
                                case "q":
                                case "Q":
                                    Console.WriteLine("SAIR");
                                    break;

                            }
                        }
                        while (alterador!= "q" && alterador != "Q");
                    }             
                
                
                }

            }
        }

        
    }

