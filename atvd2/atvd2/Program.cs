using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeProdutos
{
    class Produto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }

    class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU - GERENCIAMENTO DE PRODUTOS ===");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Remover Produto");
                Console.WriteLine("3 - Pesquisar Produto");
                Console.WriteLine("4 - Mostrar Produto com Menor Valor");
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
                    case 1: CadastrarProduto(); break;
                    case 2: RemoverProduto(); break;
                    case 3: PesquisarProduto(); break;
                    case 4: MostrarProdutoMenorValor(); break;
                    case 0: Console.WriteLine("Encerrando o programa..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione Enter para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != 0);
        }

        static void CadastrarProduto()
        {
            Console.Write("Digite a descrição do produto: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o valor do produto: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor < 0)
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            produtos.Add(new Produto { Descricao = descricao, Valor = valor });
            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void RemoverProduto()
        {
            Console.Write("Digite a descrição do produto que deseja remover: ");
            string descricao = Console.ReadLine();

            var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }

        static void PesquisarProduto()
        {
            Console.Write("Digite a descrição do produto que deseja pesquisar: ");
            string descricao = Console.ReadLine();

            var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine($"Descrição: {produto.Descricao} | Valor: R${produto.Valor:F2}");
        }

        static void MostrarProdutoMenorValor()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            var produtoMaisBarato = produtos.OrderBy(p => p.Valor).First();
            Console.WriteLine("Produto com menor valor:");
            Console.WriteLine($"Descrição: {produtoMaisBarato.Descricao} | Valor: R${produtoMaisBarato.Valor:F2}");
        }
    }
}
