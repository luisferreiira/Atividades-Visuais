
using Exercicio5;
using System;

class Program
{
    // a. Ler a base de dados
    public static void adicionarGado(List<Gado> listaGados)
    {
        Gado g = new Gado();

        Console.Write("Código: ");
        g.codigo = int.Parse(Console.ReadLine());

        Console.Write("Litros de leite por semana: ");
        g.leite = double.Parse(Console.ReadLine());

        Console.Write("Alimento consumido por semana (kg): ");
        g.alim = double.Parse(Console.ReadLine());

        Console.Write("Mês de nascimento: ");
        g.nasc.mes = int.Parse(Console.ReadLine());

        Console.Write("Ano de nascimento: ");
        g.nasc.ano = int.Parse(Console.ReadLine());

        // Classificação automática
        g.abate = verificarAbate(g);

        listaGados.Add(g);

        Console.WriteLine("Gado cadastrado com sucesso!");
    }

    // b. O sistema que deve preencher o campo abate
    public static bool verificarAbate(Gado g)
    {
        DateTime hoje = DateTime.Today;

        int idade = hoje.Year - g.nasc.ano;

        if (hoje.Month < g.nasc.mes)
        {
            idade--;
        }

        if (idade > 5 || g.leite < 40)
        {
            return true;
        }

        return false;
    }

    // Atualizar a classificação de todos os animais
    public static void atualizarAbates(List<Gado> listaGados)
    {
        foreach (Gado g in listaGados)
        {
            g.abate = verificarAbate(g);
        }
    }

    // c. Retornar a quantidade total de leite produzida por semana na fazenda
    public static void calcularTotalLeite(List<Gado> listaGados)
    {
        double totalLeite = 0;

        foreach (Gado g in listaGados)
        {
            totalLeite += g.leite;
        }

        Console.WriteLine($"Total de leite produzido por semana: {totalLeite:F2} litros");
    }

    // d. Retornar a quantidade total de alimento consumido por semana na fazenda
    public static void calcularTotalAlimento(List<Gado> listaGados)
    {
        double totalAlimento = 0;

        foreach (Gado g in listaGados)
        {
            totalAlimento += g.alim;
        }

        Console.WriteLine($"Total de alimento consumido por semana: {totalAlimento:F2} kg");
    }

    // e. Listar os animais que devem ir para o abate
    public static void mostrarGadosParaAbate(List<Gado> listaGados)
    {
        atualizarAbates(listaGados);

        bool encontrado = false;

        for (int i = 0; i < listaGados.Count; i++)
        {
            if (listaGados[i].abate)
            {
                Console.WriteLine("*** Gado para Abate ***");
                Console.WriteLine($"Código: {listaGados[i].codigo}");
                Console.WriteLine($"Leite: {listaGados[i].leite:F2} litros/semana");
                Console.WriteLine($"Alimento: {listaGados[i].alim:F2} kg/semana");
                Console.WriteLine($"Nascimento: {listaGados[i].nasc.mes:D2}/{listaGados[i].nasc.ano}");

                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Nenhum animal indicado para abate!");
        }
    }

    // Extra: Mostrar todos os animais
    public static void mostrarGados(List<Gado> listaGados)
    {
        atualizarAbates(listaGados);

        int posicao = 1;

        foreach (Gado g in listaGados)
        {
            Console.WriteLine($"*** Gado {posicao} ***");
            Console.WriteLine($"Código: {g.codigo}");
            Console.WriteLine($"Leite: {g.leite:F2} litros/semana");
            Console.WriteLine($"Alimento: {g.alim:F2} kg/semana");
            Console.WriteLine($"Nascimento: {g.nasc.mes:D2}/{g.nasc.ano}");
            Console.WriteLine($"Abate: {(g.abate ? "S" : "N")}\n");

            posicao++;
        }
    }

    // f. Salvar dados em arquivo e carregar dados
    static void salvarDados(List<Gado> listaGados, string nomeArquivo)
    {
        atualizarAbates(listaGados);

        StreamWriter writer = new StreamWriter(nomeArquivo);

        foreach (Gado g in listaGados)
        {
            writer.WriteLine($"{g.codigo};{g.leite};{g.alim};{g.nasc.mes};{g.nasc.ano};{g.abate}");
        }

        writer.Dispose();

        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void carregarDados(List<Gado> listaGados, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhasDoArquivo = File.ReadAllLines(nomeArquivo);

            listaGados.Clear();

            foreach (string linha in linhasDoArquivo)
            {
                string[] campos = linha.Split(';');

                Gado g = new Gado();

                g.codigo = int.Parse(campos[0]);
                g.leite = double.Parse(campos[1]);
                g.alim = double.Parse(campos[2]);
                g.nasc.mes = int.Parse(campos[3]);
                g.nasc.ano = int.Parse(campos[4]);

                // Recalcula o abate conforme a data atual
                g.abate = verificarAbate(g);

                listaGados.Add(g);
            }

            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    // Menu principal
    static int menu()
    {
        Console.WriteLine("=== CONTROLE DE FAZENDA ===");
        Console.WriteLine("1 - Adicionar Gado");
        Console.WriteLine("2 - Mostrar Todos os Animais");
        Console.WriteLine("3 - Calcular Total de Leite");
        Console.WriteLine("4 - Calcular Total de Alimento");
        Console.WriteLine("5 - Mostrar Animais para Abate");
        Console.WriteLine("6 - Carregar Dados");
        Console.WriteLine("0 - Salvar e Sair");
        Console.Write("Escolha uma opção: ");

        return int.Parse(Console.ReadLine());
    }

    public static void Main()
    {
        List<Gado> listaGados = new List<Gado>();
        string nomeArquivo = "Gados.txt";
        int opcao;

        carregarDados(listaGados, nomeArquivo);

        do
        {
            opcao = menu();

            switch (opcao)
            {
                case 1:
                    adicionarGado(listaGados);
                    break;

                case 2:
                    mostrarGados(listaGados);
                    break;

                case 3:
                    calcularTotalLeite(listaGados);
                    break;

                case 4:
                    calcularTotalAlimento(listaGados);
                    break;

                case 5:
                    mostrarGadosParaAbate(listaGados);
                    break;

                case 6:
                    carregarDados(listaGados, nomeArquivo);
                    break;

                case 0:
                    salvarDados(listaGados, nomeArquivo);
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (opcao != 0);
    }
}
