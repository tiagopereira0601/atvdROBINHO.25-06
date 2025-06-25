using System;

namespace SistemaDePagamentos
{
    public interface IPagamento
    {
        void ProcessarPagamento(decimal valor);
    }

    public class PagamentoCartaoCredito : IPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Pagamento de R${valor:F2} processado no cartão de crédito.");
        }
    }

    public class PagamentoBoleto : IPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Pagamento de R${valor:F2} processado via boleto bancário.");
        }
    }

    public class PagamentoPIX : IPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Pagamento de R${valor:F2} processado via PIX.");
        }
    }

    public class LojaVirtual
    {
        public void RealizarPagamento(IPagamento metodo, decimal valor)
        {
            metodo.ProcessarPagamento(valor);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LojaVirtual loja = new LojaVirtual();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE PAGAMENTOS ===");
                Console.WriteLine("1 - Cartão de Crédito");
                Console.WriteLine("2 - Boleto Bancário");
                Console.WriteLine("3 - PIX");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                if (opcao == "0")
                    break;

                Console.Write("Digite o valor do pagamento: R$");
                if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
                    continue;

                IPagamento pagamento = opcao switch
                {
                    "1" => new PagamentoCartaoCredito(),
                    "2" => new PagamentoBoleto(),
                    "3" => new PagamentoPIX(),
                    _ => null
                };

                if (pagamento == null)
                    continue;

                loja.RealizarPagamento(pagamento, valor);
                Console.WriteLine("\nPagamento realizado com sucesso!");
                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }
}
