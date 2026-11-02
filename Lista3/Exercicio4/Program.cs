using Exercicio4;
using System;

class Program
{

    
    public static void adicionarJogo(List<Jogo> listaJogos)
    {
        Jogo j = new Jogo(); // Instancia nova

        Console.Write("Título: ");
        j.titulo = Console.ReadLine();

        Console.Write("Console: ");
        j.console = Console.ReadLine();

        Console.Write("Ano: ");
        j.ano = int.Parse(Console.ReadLine());

        Console.Write("Ranking: ");
        j.ranking = int.Parse(Console.ReadLine());

        listaJogos.Add(j); // Insira o objeto na lista

        Console.WriteLine("--------");
    }

    static void salvarDados(List<Jogo> listaJogos, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);


        foreach (Jogo j in listaJogos)
        {
            writer.WriteLine($"{j.titulo};{j.console};{j.ano};{j.ranking};{j.emprestimo.nomePessoa};{j.emprestimo.dataEmprestimo:yyyy-MM-dd};{j.emprestimo.emprestado}");
            }

        writer.Dispose();
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void carregarDados(List<Jogo> listaJogos, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhasDoArquivo = File.ReadAllLines(nomeArquivo);

            listaJogos.Clear(); // Limpa a lista antes de carregar

            foreach (string linha in linhasDoArquivo)
            {
                string[] campos = linha.Split(';');
                Jogo j = new Jogo();
                j.titulo = campos[0];
                j.console = campos[1];
                j.ano = int.Parse(campos[2]);
                j.ranking = int.Parse(campos[3]);

                if (campos.Length >= 7)
                {
                    j.emprestimo.nomePessoa = campos[4];
                    j.emprestimo.dataEmprestimo = DateTime.ParseExact(
                        campos[5], "yyyy-MM-dd",
                        System.Globalization.CultureInfo.InvariantCulture
                    );
                    j.emprestimo.emprestado = bool.Parse(campos[6]);
                }

                listaJogos.Add(j);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    // a. Permita procurar o jogo por título, ou listar todos os jogos de um console.
    public static bool buscarJogoPorTitulo(List<Jogo> listaJogos, string titulo)
    {
        bool encontrado = false;

        for (int i = 0; i < listaJogos.Count; i++)
        {
            if (listaJogos[i].titulo.ToUpper().Contains(titulo.ToUpper()))
            {
                Console.WriteLine("*** Jogo ***");
                Console.WriteLine($"Título: {listaJogos[i].titulo} - Console: {listaJogos[i].console} - Ano: {listaJogos[i].ano} - Ranking: TOP {listaJogos[i].ranking}\n");

                encontrado = true;
            }
        }

        return encontrado;
    }

    public static bool buscarJogosPorConsole(List<Jogo> listaJogos, string console)
    {
        bool encontrado = false;

        for (int i = 0; i < listaJogos.Count; i++)
        {
            if (listaJogos[i].console.ToUpper().Equals(console.ToUpper()))
            {
                Console.WriteLine("*** Jogo ***");
                Console.WriteLine($"Título: {listaJogos[i].titulo} - Console: {listaJogos[i].console} - Ano: {listaJogos[i].ano} - Ranking: TOP {listaJogos[i].ranking}\n");

                encontrado = true;
            }
        }

        return encontrado;
    }
    /*
       b. Permita realizar o empréstimo de um jogo, anotando a data atual, o
          nome da pessoa que pegou o jogo e alterando o campo emprestado
          para ‘S’.   
     */

    static int buscarIndiceJogo(List<Jogo> listaJogos, string nomeJogo)
    {
        for (int i = 0; i < listaJogos.Count; i++)
        {
            if (listaJogos[i].titulo.ToUpper().Equals(nomeJogo.ToUpper())) // Compare se os nomes são iguais
            {
                return i; // Retorne o índice onde Jogo foi encontrado
            }
        }
        return -1; // Retorne o valor padrão que indica "não encontrado"
    }

    public static bool emprestarJogo(List<Jogo> listaJogos, string titulo) {
        int indice = buscarIndiceJogo(listaJogos, titulo);

        if (indice == -1)
        {
            Console.WriteLine("Jogo não encontrado!");
            return false;
        }

        if (listaJogos[indice].emprestimo.emprestado) {
            Console.WriteLine("Este jogo já está emprestado!");
            return false;
        }

        Console.Write("Nome da pessoa: ");
        string nomePessoa = Console.ReadLine();

        listaJogos[indice].emprestimo.nomePessoa = nomePessoa;
        listaJogos[indice].emprestimo.dataEmprestimo = DateTime.Today;
        listaJogos[indice].emprestimo.emprestado = true;

        Console.WriteLine("Empréstimo realizado com sucesso!");

        return true;
    }

    // c. Permita devolver o jogo definindo o campo emprestado para ‘N’.

    public static bool devolverJogo(List<Jogo> listaJogos, string titulo) {
        int indice = buscarIndiceJogo(listaJogos, titulo);

        if (indice == -1)
        {
            Console.WriteLine("Jogo não encontrado!");
            return false;
        }

        if (!listaJogos[indice].emprestimo.emprestado)
        {
            Console.WriteLine("Este jogo não está emprestado!");
            return false;
        }

        listaJogos[indice].emprestimo.emprestado = false;

        Console.WriteLine("Jogo devolvido com sucesso!");

        return true;
    }


    // d. Mostre todos os jogos que estão emprestados e para quem.
    public static void mostrarJogosEmprestados(List<Jogo> listaJogos)
    {
        bool encontrado = false;
        for (int i = 0; i < listaJogos.Count; i++) // Percorra até o tamanho da lista
        {
            if (listaJogos[i].emprestimo.emprestado)
            {
                Console.WriteLine($"*** Jogo ***");
                Console.WriteLine($"Título: {listaJogos[i].titulo} - Empréstimo para {listaJogos[i].emprestimo.nomePessoa}\n");
                encontrado = true;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Nenhum jogo está emprestado!");
        }
    }

    // extra: mostra todos
    public static void mostrarJogos(List<Jogo> listaJogos)
    {
        int posicao = 1;
        foreach (Jogo j in listaJogos) // Percorra cada 
        {
            Console.WriteLine($"*** Jogo {posicao} ***");
            Console.WriteLine($"Título: {j.titulo} - Console: {j.console} - Ano: {j.ano} - Ranking: TOP {j.ranking}\n");
            posicao++;
        }

    }


    /*  menu */
    static int menu()
    {
        Console.WriteLine("=== CONTROLE DE JOGOS ===");
        Console.WriteLine("1 - Adicionar Jogo");
        Console.WriteLine("2 - Mostrar Todos os Jogos");
        Console.WriteLine("3 - Buscar Jogos");
        Console.WriteLine("4 - Emprestar Jogo");
        Console.WriteLine("5 - Devolver Jogo");
        Console.WriteLine("6 - Mostrar Jogos Emprestados");
        Console.WriteLine("7 - Carregar Dados");
        Console.WriteLine("0 - Salvar e Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static int menuBusca()
    {
        Console.WriteLine("=== BUSCAR JOGOS ===");
        Console.WriteLine("1 - Buscar Jogo por Título");
        Console.WriteLine("2 - Buscar Jogos por Console");
        Console.WriteLine("0 - Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");

        return int.Parse(Console.ReadLine());
    }

    public static void Main()
    {
        List<Jogo> listaJogos = new List<Jogo>();
        string nomeArquivo = "Jogos.txt";
        int opcao;

        carregarDados(listaJogos, nomeArquivo); // Carrega ao iniciar

        do
        {
            opcao = menu();

            switch (opcao)
            {
                case 1:
                    adicionarJogo(listaJogos);
                    break;

                case 2:
                    mostrarJogos(listaJogos);
                    break;

                case 3:
                    {
                        int opcaoBusca;

                        do
                        {
                            opcaoBusca = menuBusca();

                            switch (opcaoBusca)
                            {
                                case 1:
                                    {
                                        Console.Write("\nDigite o título do jogo: ");
                                        string titulo = Console.ReadLine();

                                        bool encontrado = buscarJogoPorTitulo(listaJogos, titulo);

                                        if (!encontrado)
                                        {
                                            Console.WriteLine("Jogo não encontrado!");
                                        }
                                        break;
                                    }

                                case 2:
                                    {
                                        Console.Write("\nDigite o console: ");
                                        string console = Console.ReadLine();

                                        bool encontrado = buscarJogosPorConsole(listaJogos, console);

                                        if (!encontrado)
                                        {
                                            Console.WriteLine("Nenhum jogo encontrado para este console!");
                                        }
                                        break;
                                    }

                                case 0:
                                    Console.WriteLine("Voltando ao menu principal...");
                                    break;

                                default:
                                    Console.WriteLine("Opção inválida!");
                                    break;
                            }

                            if (opcaoBusca != 0)
                            {
                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }

                        } while (opcaoBusca != 0);

                        break;
                    }

                case 4:
                    {
                        // Realizar empréstimo
                        Console.Write("\nDigite o título do jogo que deseja emprestar: ");
                        string titulo = Console.ReadLine();

                        emprestarJogo(listaJogos, titulo);
                        break;
                    }

                case 5:
                    {
                        // Devolver jogo
                        Console.Write("\nDigite o título do jogo que deseja devolver: ");
                        string titulo = Console.ReadLine();

                        devolverJogo(listaJogos, titulo);
                        break;
                    }

                case 6:
                    // Mostrar jogos emprestados
                    mostrarJogosEmprestados(listaJogos);
                    break;

                case 7:
                    carregarDados(listaJogos, nomeArquivo);
                    break;

                case 0:
                    salvarDados(listaJogos, nomeArquivo);
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