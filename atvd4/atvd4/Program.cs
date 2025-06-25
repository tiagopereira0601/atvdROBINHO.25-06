using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== DIVISÃO DE NÚMEROS ===");
            Console.WriteLine("Digite 'sair' a qualquer momento para encerrar.\n");

            int numero1 = 0;
            int numero2 = 0;

            while (true)
            {
                Console.Write("Digite o primeiro número: ");
                string entrada1 = Console.ReadLine();

                if (entrada1.ToLower() == "sair")
                    return;

                try
                {
                    numero1 = int.Parse(entrada1);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Valor inválido. Digite um número inteiro.");
                }
            }

            while (true)
            {
                Console.Write("Digite o segundo número: ");
                string entrada2 = Console.ReadLine();

                if (entrada2.ToLower() == "sair")
                    return;

                try
                {
                    numero2 = int.Parse(entrada2);
                    int resultado = numero1 / numero2;
                    Console.WriteLine($"\nResultado: {resultado}");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Valor inválido. Digite um número inteiro.");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Erro: Não é possível dividir por zero.");
                }
            }

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
