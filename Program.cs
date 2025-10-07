
using System.Net.NetworkInformation;

namespace Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BEM VINDO AO SISTEMA HOSPITALAR");
            Paciente[] filaPreferencial = new Paciente[15];
            Paciente[] filaNormal = new Paciente[15];
            int qtdNorma = 0;
            int qtdPreferencial = 0;
            string opcao;

            do
            {
                Console.WriteLine("\n Escolha uma opção:");
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
                        atenderPaciente();
                        break;
                    case "4":
                        alterarDados();
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("Adeus");
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVALIDA");
                        break;
                }
            }
            while (opcao != "Q" && opcao != "q");

            void cadastrarPaciente()
            {
                Paciente p = new Paciente();

                Console.Write("Nome: ");
                p.nome = Console.ReadLine();
                Console.Write("Idade: ");
                p.idade = int.Parse(Console.ReadLine());
                Console.Write("CPF: ");
                p.cpf = Console.ReadLine();
                Console.Write("É preferencial? (s/n): ");
                string aux = Console.ReadLine();

                if (aux == "s" || aux == "S")
                {
                    p.prioridade = true;
                    filaPreferencial[qtdPreferencial] = p;
                    qtdPreferencial++;
                }
                else
                {
                    p.prioridade = false;
                    filaNormal[qtdNorma] = p;
                    qtdNorma++;
                }

                Console.WriteLine($"Paciente {p.nome} cadastrado com sucesso");

            }

            void mostrarPacientes()
            {
                Console.WriteLine("Lista Preferencial");
                if (qtdPreferencial == 0)
                {
                    Console.WriteLine("FILA PREFERENCIAL VAZIA");
                }

                for (int i = 0; i < qtdPreferencial; i++)
                {
                    Console.Write($"Nome:{filaPreferencial[i].nome}, Idade: {filaPreferencial[i].idade} anos, CPF: {filaPreferencial[i].cpf}");
                }

                Console.WriteLine("Lista dos não Preferencial");
                if (qtdPreferencial == 0)
                {
                    Console.WriteLine("FILA NÃO PREFERENCIAL VAZIA");
                }
                for (int i = 0; i < qtdNorma; i++)
                {
                    Console.WriteLine("-----------------");
                    Console.Write($"Nome:{filaNormal[i].nome}, Idade: {filaNormal[i].idade} anos, CPF: {filaNormal[i].cpf}");
                }

            }

            void atenderPaciente()
            {
                if (qtdPreferencial == 0 && qtdNorma == 0)
                {
                    Console.WriteLine("FILA VAZIA");

                }
                if (qtdPreferencial > 0)
                {
                    Console.WriteLine($"ATENDENDO: {filaPreferencial[0].nome}");
                    for (int i = 0; i < qtdPreferencial - 1; i++)
                    {
                        filaPreferencial[i] = filaPreferencial[i + 1];
                    }
                    filaPreferencial[qtdPreferencial - 1] = null;
                    qtdPreferencial--;

                    for (int i = 0; i < qtdNorma - 1; i++)
                    {
                        filaNormal[i] = filaNormal[i + 1];
                    }
                    filaPreferencial[qtdNorma - 1] = null;
                    qtdPreferencial--;

                }

            }

            void alterarDados()
            {
                if (qtdNorma == 0 && qtdPreferencial == 0)
                {
                    Console.WriteLine();
                }
                
            }

        }
    }
}

