using System;
using System.Collections.Generic;
using System.Linq;

class Competidor
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Modalidade { get; set; }

    public Competidor(string nome, int idade, string modalidade)
    {
        Nome = nome;
        Idade = idade;
        Modalidade = modalidade;
    }
}

class Competicao
{
    public string Nome { get; set; }
    private List<Competidor> competidores = new List<Competidor>();

    public Competicao(string nome)
    {
        Nome = nome;
    }

    public void AdicionarCompetidor(Competidor c)
    {
        competidores.Add(c);
    }

    public List<Competidor> ObterCompetidores()
    {
        return competidores;
    }

    public bool RemoverCompetidor(string nome)
    {
        var c = competidores.FirstOrDefault(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (c != null)
        {
            competidores.Remove(c);
            return true;
        }
        return false;
    }

    public bool EditarCompetidor(string nome, string novoNome, int novaIdade, string novaModalidade)
    {
        var c = competidores.FirstOrDefault(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (c != null)
        {
            c.Nome = novoNome;
            c.Idade = novaIdade;
            c.Modalidade = novaModalidade;
            return true;
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        Competicao competicao = null;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU COMPETIÇÃO ===");
            Console.WriteLine("1 - Cadastrar nova competição");
            Console.WriteLine("2 - Adicionar competidor");
            Console.WriteLine("3 - Listar competidores");
            Console.WriteLine("4 - Editar competidor");
            Console.WriteLine("5 - Remover competidor");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome da competição: ");
                    string nome = Console.ReadLine();
                    competicao = new Competicao(nome);
                    Console.WriteLine($"Competição '{nome}' criada com sucesso!");
                    break;

                case "2":
                    if (competicao == null)
                    {
                        Console.WriteLine("Crie uma competição primeiro.");
                        break;
                    }

                    Console.Write("Nome do competidor: ");
                    string nomeComp = Console.ReadLine();
                    Console.Write("Idade: ");
                    if (!int.TryParse(Console.ReadLine(), out int idadeComp))
                    {
                        Console.WriteLine("Idade inválida.");
                        break;
                    }
                    Console.Write("Modalidade: ");
                    string modalidade = Console.ReadLine();

                    competicao.AdicionarCompetidor(new Competidor(nomeComp, idadeComp, modalidade));
                    Console.WriteLine("Competidor adicionado com sucesso!");
                    break;

                case "3":
                    if (competicao == null)
                    {
                        Console.WriteLine("Nenhuma competição criada.");
                        break;
                    }

                    var lista = competicao.ObterCompetidores();
                    if (lista.Count == 0)
                    {
                        Console.WriteLine("Nenhum competidor cadastrado.");
                    }
                    else
                    {
                        Console.WriteLine($"Competição: {competicao.Nome}");
                        foreach (var c in lista)
                        {
                            Console.WriteLine($"Nome: {c.Nome} | Idade: {c.Idade} | Modalidade: {c.Modalidade}");
                        }
                    }
                    break;

                case "4":
                    if (competicao == null)
                    {
                        Console.WriteLine("Nenhuma competição criada.");
                        break;
                    }

                    Console.Write("Digite o nome do competidor a editar: ");
                    string antigoNome = Console.ReadLine();
                    Console.Write("Novo nome: ");
                    string novoNome = Console.ReadLine();
                    Console.Write("Nova idade: ");
                    if (!int.TryParse(Console.ReadLine(), out int novaIdade))
                    {
                        Console.WriteLine("Idade inválida.");
                        break;
                    }
                    Console.Write("Nova modalidade: ");
                    string novaMod = Console.ReadLine();

                    if (competicao.EditarCompetidor(antigoNome, novoNome, novaIdade, novaMod))
                        Console.WriteLine("Competidor editado com sucesso!");
                    else
                        Console.WriteLine("Competidor não encontrado.");
                    break;

                case "5":
                    if (competicao == null)
                    {
                        Console.WriteLine("Nenhuma competição criada.");
                        break;
                    }

                    Console.Write("Digite o nome do competidor a remover: ");
                    string removerNome = Console.ReadLine();

                    if (competicao.RemoverCompetidor(removerNome))
                        Console.WriteLine("Competidor removido.");
                    else
                        Console.WriteLine("Competidor não encontrado.");
                    break;

                case "0":
                    Console.WriteLine("Encerrando...");
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("\nPressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
