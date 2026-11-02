using Exercicio2;
using System;

class Program {

    // a. Crie uma estrutura para armazenar os dados de cada eletrodoméstico
    public static void adicionarEletrodomestico(List<Eletrodomestico> listaEletrodomesticos)
    {
        Eletrodomestico e = new Eletrodomestico(); // Instancia nova

        Console.Write("Nome: ");
        e.nome = Console.ReadLine();

        Console.Write("Potência (kW): ");
        e.potencia = double.Parse(Console.ReadLine());

        Console.Write("Tempo Médio Ativo por dia (horas): ");
        e.tempoMedioAtivoPorDia = double.Parse(Console.ReadLine());

        listaEletrodomesticos.Add(e); // Insira o objeto na lista

        Console.WriteLine("--------");
    }

    // b. Permite listar em tela e salvar em um arquivo.
    public static void mostrarEletrodomesticos(List<Eletrodomestico> listaEletrodomesticos)
    {
        int posicao = 1;
        foreach (Eletrodomestico e in listaEletrodomesticos) // Percorra cada Banda b na lista
        {
            Console.WriteLine($"*** Eletrodoméstico {posicao} ***");
            Console.WriteLine($"{e.nome} - Potência {e.potencia:F2} kW - {e.tempoMedioAtivoPorDia:F2} hora(s)");
            posicao++;
        }

    }

    static void salvarDados(List<Eletrodomestico> listaEletrodomesticos, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);


        foreach (Eletrodomestico e in listaEletrodomesticos)
        {
            writer.WriteLine($"{e.nome};{e.potencia};{e.tempoMedioAtivoPorDia}");
        }

        writer.Dispose();
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void carregarDados(List<Eletrodomestico> listaEletrodomesticos, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhasDoArquivo = File.ReadAllLines(nomeArquivo);

            listaEletrodomesticos.Clear(); // Limpa a lista antes de carregar

            foreach (string linha in linhasDoArquivo)
            {
                string[] campos = linha.Split(';');
                Eletrodomestico e = new Eletrodomestico();
                e.nome = campos[0];
                e.potencia = double.Parse(campos[1]);
                e.tempoMedioAtivoPorDia = double.Parse(campos[2]);
                listaEletrodomesticos.Add(e);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    // c. Permita buscar pelo seu nome.
    public static bool buscarEletrodomesticoPorNome(List<Eletrodomestico> listaEletrodomesticos, string nome) {
        bool encontrado = false;
        for (int i = 0; i < listaEletrodomesticos.Count; i++) // Percorra até o tamanho da lista
        {
            if (listaEletrodomesticos[i].nome.ToUpper().Equals(nome.ToUpper()))
            {
                Console.WriteLine($"*** Eletrodoméstico ***");
                Console.WriteLine($"Nome: {listaEletrodomesticos[i].nome}");
                Console.WriteLine($"Potência: {listaEletrodomesticos[i].potencia:F2} kW");
                Console.WriteLine($"Tempo Médio Ativo por dia: {listaEletrodomesticos[i].tempoMedioAtivoPorDia:F2} hora(s)");
                encontrado = true;
            }
        }
        return encontrado;
    }

    // d. Permita buscar pelos eletrodomésticos que gastam mais que um valor X.
    public static bool buscarEletromesticoPorConsumoKw(List<Eletrodomestico> listaEletrodomesticos, double consumoKwh)
    {
        bool encontrado = false;
        for (int i = 0; i < listaEletrodomesticos.Count; i++) // Percorra até o tamanho da lista
        {
            double consumoDiario =
            listaEletrodomesticos[i].potencia *
            listaEletrodomesticos[i].tempoMedioAtivoPorDia;

            if (consumoDiario > consumoKwh)
            {
                Console.WriteLine($"*** Eletrodoméstico ***");
                Console.WriteLine($"Nome: {listaEletrodomesticos[i].nome}");
                Console.WriteLine($"Potência: {listaEletrodomesticos[i].potencia:F2} kW");
                Console.WriteLine($"Tempo Médio Ativo por dia: {listaEletrodomesticos[i].tempoMedioAtivoPorDia:F2} hora(s)");
                encontrado = true;
            }
        }
        return encontrado;
    }

    /* e. Calcule e mostre o consumo diário e mensal da casa em kW e R$. 
          Para mostrar em R$ receba o valor do kW/h.*/

public static void calcularConsumo(List<Eletrodomestico> listaEletrodomesticos, double custoKwhEmReais) {
        
        double consumoTotalDiario = 0;

        foreach (Eletrodomestico e in listaEletrodomesticos) {
            double consumoDiario = e.potencia * e.tempoMedioAtivoPorDia;
            consumoTotalDiario = consumoTotalDiario + consumoDiario;
        }

        double consumoTotalMensal = consumoTotalDiario * 30;

        double custoDiario = consumoTotalDiario * custoKwhEmReais;
        double custoMensal = consumoTotalMensal * custoKwhEmReais;

        Console.WriteLine($"\nConsumo diário: {consumoTotalDiario:F2} kWh");
        Console.WriteLine($"Consumo mensal: {consumoTotalMensal:F2} kWh");

        Console.WriteLine($"\nCusto diário: R${custoDiario:F2}");
        Console.WriteLine($"Custo mensal: R${custoMensal:F2}");

    }


    /* f. Organize tudo em uma aplicação que exiba um menu as opções de preencher
          as estruturas e todas as opções das questões passadas mais a possibilidade do
          usuário carregar os dados já gravados.*/
    static int menu()
{
    Console.WriteLine("=== CONTROLE DE ENERGIA ===");
    Console.WriteLine("1 - Adicionar Eletrodoméstico");
    Console.WriteLine("2 - Mostrar Eletrodomésticos");
    Console.WriteLine("3 - Buscar Eletrodoméstico por Nome");
    Console.WriteLine("4 - Buscar Eletrodoméstico por Consumo");
    Console.WriteLine("5 - Calcular Consumo");
    Console.WriteLine("6 - Carregar Dados");
    Console.WriteLine("0 - Salvar e Sair");
    Console.Write("Escolha uma opção: ");
    return int.Parse(Console.ReadLine());
}


    public static void Main()
    {
        List<Eletrodomestico> listaEletrodomesticos = new List<Eletrodomestico>();
        string nomeArquivo = "eletrodomesticos.txt";
        int opcao;

        carregarDados(listaEletrodomesticos, nomeArquivo); // Carrega ao iniciar

        do
        {
            opcao = menu();

            switch (opcao)
            {
                case 1:
                    adicionarEletrodomestico(listaEletrodomesticos);
                    break;

                case 2:
                    mostrarEletrodomesticos(listaEletrodomesticos);
                    break;

                case 3:
                    {
                        // Buscar por nome
                        Console.Write("\nDigite o nome do eletrodoméstico: ");
                        string nome = Console.ReadLine();

                        bool encontrado = buscarEletrodomesticoPorNome(
                            listaEletrodomesticos, nome);

                        if (!encontrado)
                        {
                            Console.WriteLine("Eletrodoméstico não encontrado!");
                        }
                        break;
                    }

                case 4:
                    {
                        // Buscar por consumo diário
                        Console.Write("\nDigite o consumo mínimo diário (kWh): ");
                        double consumoKwh = double.Parse(Console.ReadLine());

                        bool encontrado = buscarEletromesticoPorConsumoKw(
                            listaEletrodomesticos, consumoKwh);

                        if (!encontrado)
                        {
                            Console.WriteLine("Nenhum eletrodoméstico encontrado!");
                        }
                        break;
                    }

                case 5:
                    {
                        // Calcular consumo diário e mensal
                        Console.Write("\nDigite o valor do kWh em R$: ");
                        double custoKwhEmReais = double.Parse(Console.ReadLine());

                        calcularConsumo(listaEletrodomesticos, custoKwhEmReais);
                        break;
                    }

                case 6:
                    carregarDados(listaEletrodomesticos, nomeArquivo);
                    break;

                case 0:
                    salvarDados(listaEletrodomesticos, nomeArquivo);
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