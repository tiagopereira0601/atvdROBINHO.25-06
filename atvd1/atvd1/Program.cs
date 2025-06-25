using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeAlunos
{
    class Aluno
    {
        public string RA { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    class Program
    {
        static List<Aluno> alunos = new List<Aluno>();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU - GERENCIAMENTO DE ALUNOS ===");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Listar Alunos");
                Console.WriteLine("3 - Alterar Aluno");
                Console.WriteLine("4 - Remover Aluno");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                    Console.ReadLine();
                    continue;
                }

                switch (opcao)
                {
                    case 1: CadastrarAluno(); break;
                    case 2: ListarAlunos(); break;
                    case 3: AlterarAluno(); break;
                    case 4: RemoverAluno(); break;
                    case 0: Console.WriteLine("Encerrando programa..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione Enter para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != 0);
        }

        static void CadastrarAluno()
        {
            Console.Write("Digite o RA do aluno: ");
            string ra = Console.ReadLine();

            if (alunos.Any(a => a.RA == ra))
            {
                Console.WriteLine("Já existe um aluno com esse RA.");
                return;
            }

            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida.");
                return;
            }

            alunos.Add(new Aluno { RA = ra, Nome = nome, Idade = idade });
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        static void ListarAlunos()
        {
            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
                return;
            }

            Console.WriteLine("=== Lista de Alunos ===");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"RA: {aluno.RA} | Nome: {aluno.Nome} | Idade: {aluno.Idade}");
            }
        }

        static void AlterarAluno()
        {
            Console.Write("Digite o RA do aluno que deseja alterar: ");
            string ra = Console.ReadLine();

            var aluno = alunos.FirstOrDefault(a => a.RA == ra);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            Console.Write("Digite o novo nome: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("Digite a nova idade: ");
            if (!int.TryParse(Console.ReadLine(), out int novaIdade))
            {
                Console.WriteLine("Idade inválida.");
                return;
            }
            aluno.Idade = novaIdade;

            Console.WriteLine("Dados alterados com sucesso!");
        }

        static void RemoverAluno()
        {
            Console.Write("Digite o RA do aluno que deseja remover: ");
            string ra = Console.ReadLine();

            var aluno = alunos.FirstOrDefault(a => a.RA == ra);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            alunos.Remove(aluno);
            Console.WriteLine("Aluno removido com sucesso!");
        }
    }
}
