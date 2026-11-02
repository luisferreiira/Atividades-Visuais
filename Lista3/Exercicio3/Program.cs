using Exercicio3;
using System;

class Program
{

    // b. Permita cadastrar livros
    public static void adicionarLivro(List<Livro> listaLivros)
    {
        Livro l = new Livro(); // Instancia nova

        Console.Write("Título: ");
        l.titulo = Console.ReadLine();

        Console.Write("Autor: ");
        l.autor = Console.ReadLine();

        Console.Write("Ano: ");
        l.ano = int.Parse(Console.ReadLine());

        Console.Write("Prateleira: ");
        l.prateleira = Console.ReadLine();

        listaLivros.Add(l); // Insira o objeto na lista

        Console.WriteLine("--------");
    }

    

    static void salvarDados(List<Livro> listaLivros, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);


        foreach (Livro l in listaLivros)
        {
            writer.WriteLine($"{l.titulo};{l.autor};{l.ano};{l.prateleira}");
        }

        writer.Dispose();
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void carregarDados(List<Livro> listaLivros, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhasDoArquivo = File.ReadAllLines(nomeArquivo);

            listaLivros.Clear(); // Limpa a lista antes de carregar

            foreach (string linha in linhasDoArquivo)
            {
                string[] campos = linha.Split(';');
                Livro l = new Livro();
                l.titulo = campos[0];
                l.autor = campos[1];
                l.ano = int.Parse(campos[2]);
                l.prateleira = campos[3];
                listaLivros.Add(l);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    // c. Procure um livro por título, perguntando ao usuário qual tıtulo deseja buscar,
    //    apresente o nome e em qual prateleira o mesmo se encontra.
    public static bool buscarLivroPorTitulo(List<Livro> listaLivros, string nome)
    {
        bool encontrado = false;
        for (int i = 0; i < listaLivros.Count; i++) // Percorra até o tamanho da lista
        {
            if (listaLivros[i].titulo.ToUpper().Contains(nome.ToUpper()))
            {
                Console.WriteLine($"*** Livro ***");
                Console.WriteLine($"Título: {listaLivros[i].titulo} - Prateleira: {listaLivros[i].prateleira}\n");
                encontrado = true;
            }
        }
        return encontrado;
    }

    // d. Mostre os dados de todos os livros cadastrados.
    public static void mostrarLivros(List<Livro> listaLivros)
    {
        int posicao = 1;
        foreach (Livro l in listaLivros) // Percorra cada 
        {
            Console.WriteLine($"*** Livro {posicao} ***");
            Console.WriteLine($"{l.titulo} - Autor: {l.autor} - ({l.ano}) - Prateleira: {l.prateleira}\n");
            posicao++;
        }

    }

    // e. Leia um ano e apresente todos os livros mais novos que o ano lido.
    public static bool buscarLivroPorAnoMinimo(List<Livro> listaLivros, int ano)
    {
        bool encontrado = false;
        for (int i = 0; i < listaLivros.Count; i++) // Percorra até o tamanho da lista
        {

            if (listaLivros[i].ano > ano)
            {
                Console.WriteLine($"*** Livro ***");
                Console.WriteLine($"{listaLivros[i].titulo} - Autor: {listaLivros[i].autor} - ({listaLivros[i].ano}) - Prateleira: {listaLivros[i].prateleira}\n");
                encontrado = true;
            }
        }
        return encontrado;
    }

    /*  menu */
    static int menu()
    {
        Console.WriteLine("=== CONTROLE DE LIVROS ===");
        Console.WriteLine("1 - Adicionar Livro");
        Console.WriteLine("2 - Mostrar Livros");
        Console.WriteLine("3 - Buscar Livro por Título");
        Console.WriteLine("4 - Buscar Livros por Ano Mínimo");
        Console.WriteLine("5 - Carregar Dados");
        Console.WriteLine("0 - Salvar e Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    public static void Main()
    {
        List<Livro> listaLivros = new List<Livro>();
        string nomeArquivo = "Livros.txt";
        int opcao;

        carregarDados(listaLivros, nomeArquivo); // Carrega ao iniciar

        do
        {
            opcao = menu();

            switch (opcao)
            {
                case 1:
                    adicionarLivro(listaLivros);
                    break;

                case 2:
                    mostrarLivros(listaLivros);
                    break;

                case 3:
                    {
                        // Buscar por título
                        Console.Write("\nDigite o título do livro: ");
                        string nome = Console.ReadLine();

                        bool encontrado = buscarLivroPorTitulo(listaLivros, nome);

                        if (!encontrado)
                        {
                            Console.WriteLine("Livro não encontrado!");
                        }
                        break;
                    }

                case 4:
                    {
                        // Buscar livros mais novos que o ano informado
                        Console.Write("\nDigite o ano mínimo: ");
                        int ano = int.Parse(Console.ReadLine());

                        bool encontrado = buscarLivroPorAnoMinimo(listaLivros, ano);

                        if (!encontrado)
                        {
                            Console.WriteLine("Nenhum livro encontrado!");
                        }
                        break;
                    }

                case 5:
                    carregarDados(listaLivros, nomeArquivo);
                    break;

                case 0:
                    salvarDados(listaLivros, nomeArquivo);
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