using CadastroBandasConsoleApp2026;
using System;

class Program
{
    // a) Crie uma função que permita cadastrar bancas.
    public static void addBanda(List<Banda> listaBandas)
    {
        Banda novaBanda = new Banda(); // Instancie uma nova Banda

        Console.Write("Nome: ");
        novaBanda.nome = Console.ReadLine();

        Console.Write("Gênero: ");
        novaBanda.genero = Console.ReadLine();

        Console.Write("Integrantes: ");
        novaBanda.integrantes = int.Parse(Console.ReadLine());

        Console.Write("Ranking da Banda: ");
        novaBanda.ranking = int.Parse(Console.ReadLine());

        listaBandas.Add(novaBanda); // Insira o objeto novaBanda na lista
        Console.WriteLine("--------");
    }

    // b) Crie uma função que liste todas bandas cadastradas.
    public static void mostrarBandas(List<Banda> listaBandas)
    {
        int posicao = 1;
        foreach (Banda b in listaBandas) // Percorra cada Banda b na lista
        {
            Console.WriteLine($"*** Banda {posicao} ***");
            Console.WriteLine($"{b.nome} - Gênero {b.genero} - {b.integrantes} Integrantes - TOP {b.ranking}");
            posicao++;
        }

    }

    // c) Salve todos os dados em um arquivo e permita carregar posteriormente.

    static void salvarDados(List<Banda> listadeBandas, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);


        foreach (Banda banda in listadeBandas)
        {
            writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
        }

        writer.Dispose();
        Console.WriteLine("Dados salvos com sucesso!");
    }

    static void carregarDados(List<Banda> listadeBandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhasDoArquivo = File.ReadAllLines(nomeArquivo);

            listadeBandas.Clear(); // Limpa a lista antes de carregar

            foreach (string linha in linhasDoArquivo)
            {
                string[] campos = linha.Split(',');
                Banda banda = new Banda();
                banda.nome = campos[0];
                banda.genero = campos[1];
                banda.integrantes = int.Parse(campos[2]);
                banda.ranking = int.Parse(campos[3]);
                listadeBandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    // d) Seu programa deve exibir informações das bandas cuja posição no seu ranking é a que foi solicitada pelo usuário
    public static bool buscarBandaPorRanking(List<Banda> listaBandas, int ranking)
    {
        bool encontrado = false;
        for (int i = 0; i < listaBandas.Count; i++) // Percorra até o tamanho da lista
        {
            if (listaBandas[i].ranking.Equals(ranking))
            {
                Console.WriteLine($"*** Banda ***");
                Console.WriteLine($"Nome: {listaBandas[i].nome}");
                Console.WriteLine($"Gênero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                encontrado = true;
            }
        }
        return encontrado;
    }

    // e) Crie uma função em que peça ao usuário um gênero de música e exiba todos dados das bandas com este genero.
    public static bool buscarBandaPorGenero(List<Banda> listaBandas, string genero) {
        bool encontrado = false;
        for (int i = 0; i < listaBandas.Count; i++) // Percorra até o tamanho da lista
        {
            if (listaBandas[i].genero.ToUpper().Equals(genero.ToUpper()))
            {
                Console.WriteLine($"*** Banda ***");
                Console.WriteLine($"Nome: {listaBandas[i].nome}");
                Console.WriteLine($"Gênero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                encontrado = true;
            }
        }
        return encontrado;
    }

    // f) Crie uma função que peça o nome de uma banda ao usuário e retorne com todos os dados desta banda.
    public static bool buscarBandaPorNome(List<Banda> listaBandas, string nomeBanda)
    {
        bool encontrado = false;
        for (int i = 0; i < listaBandas.Count; i++) // Percorra até o tamanho da lista
        {
            if (listaBandas[i].nome.ToUpper().Contains(nomeBanda.ToUpper()))
            {
                Console.WriteLine($"*** Banda ***");
                Console.WriteLine($"Nome: {listaBandas[i].nome}");
                Console.WriteLine($"Gênero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                encontrado = true;
            }
        }
        return encontrado;
    }

    static int buscarIndiceBanda(List<Banda> listaBandas, string nomeBanda)
    {
        for (int i = 0; i < listaBandas.Count; i++)
        {
            if (listaBandas[i].nome.ToUpper().Equals(nomeBanda.ToUpper())) // Compare se os nomes são iguais
            {
                Console.WriteLine($"*** Banda ***");
                Console.WriteLine($"Nome: {listaBandas[i].nome}");
                Console.WriteLine($"Gênero: {listaBandas[i].genero}");
                Console.WriteLine($"Integrantes: {listaBandas[i].integrantes}");
                Console.WriteLine($"Ranking: {listaBandas[i].ranking}");
                return i; // Retorne o índice onde a banda foi encontrada
            }
        }
        return -1; // Retorne o valor padrão que indica "não encontrado"
    }

    // g) Crie uma opção excluir uma banda.
    static bool removerBanda(List<Banda> listaBandas, string nomeBanda)
    {
        int indice = buscarIndiceBanda(listaBandas, nomeBanda);
        if (indice != -1)
        {
            Console.Write("Confirma a remoção da banda? (1-Sim / 2-Não): ");
            int confirmacao = int.Parse(Console.ReadLine());
            if (confirmacao == 1)
            {
                listaBandas.RemoveAt(indice); // Remova o elemento (RemoveAt) 
                return true;
            }
            else
            {
                Console.WriteLine("Remoção cancelada!");
                return false;
            }
        }
        Console.WriteLine("Banda Não Encontrada!");
        return false;
    }

    // h) Crie uma função para alterar os dados de uma banda [após encontrar a banda, leia novamente todos os dados].
    static bool atualizarBanda(List<Banda> listaBandas, string nomeBanda)
    {
        int indice = buscarIndiceBanda(listaBandas, nomeBanda); // Busque o índice da banda

        if (indice != -1)
        {
            Console.Write("Novo Nome:");
            listaBandas[indice].nome = Console.ReadLine();

            Console.Write("Novo Gênero:");
            listaBandas[indice].genero = Console.ReadLine();

            Console.Write("Novos Integrantes:");
            listaBandas[indice].integrantes = int.Parse(Console.ReadLine());

            Console.Write("Novo Ranking:");
            listaBandas[indice].ranking = int.Parse(Console.ReadLine());

            return true;
        }

        return false;
    }

    /* i) Organize tudo em uma aplicação que exibe um menu as opções de preencher as estruturas e
    todas as opções das questões passadas mais a possibilidade do usuário carregar os dados já
    gravados.*/

    static int menu()
    {
        Console.WriteLine("=== SISTEMA DE CADASTRO DE BANDAS ===");
        Console.WriteLine("1 - Adicionar Banda");
        Console.WriteLine("2 - Mostrar Bandas");
        Console.WriteLine("3 - Buscar Banda");
        Console.WriteLine("4 - Atualizar Banda");
        Console.WriteLine("5 - Remover Banda");
        Console.WriteLine("6 - Carregar Dados");
        Console.WriteLine("0 - Salvar e Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static int menuBusca() {
        Console.WriteLine("=== BUSCAR BANDAS ===");
        Console.WriteLine("1 - Buscar Banda Por Nome");
        Console.WriteLine("2 - Buscar Banda Por Gênero");
        Console.WriteLine("3 - Buscar Banda Por Ranking");
        Console.WriteLine("0 - Voltar");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine());
    }

    static void Main()
    {
        List<Banda> listaBandas = new List<Banda>(); // vetor de bandas
        string nomeArquivo = "bandas.txt";
        int opcao;

        carregarDados(listaBandas, nomeArquivo); // Carrega ao iniciar

        do
        {
            opcao = menu();
            switch (opcao) {
                case 1: addBanda(listaBandas); 
                    break;
                case 2: mostrarBandas(listaBandas);
                    break;
                
                case 3:
                    int opcaoBusca = menuBusca();

                    switch (opcaoBusca)
                    {
                        case 1:
                            { // Buscar por nome
                                Console.WriteLine("\nInsira o nome da banda que deseja buscar:");
                                string nomeBanda = Console.ReadLine();
                                bool encontrado = buscarBandaPorNome(listaBandas, nomeBanda);
                                if (!encontrado)
                                {
                                    Console.WriteLine("Banda Não Encontrada");
                                }
                                break;
                            }
                           
                        case 2:
                            { // Buscar por gênero
                                Console.WriteLine("\nInsira o nome do gênero que deseja buscar:");
                                string genero = Console.ReadLine();
                                bool encontrado = buscarBandaPorGenero(listaBandas, genero);
                                if (!encontrado)
                                {
                                    Console.WriteLine("Banda Não Encontrada");
                                }
                                break;
                            }

                        case 3:
                            { // Buscar por ranking
                                Console.WriteLine("\nInsira o ranking da banda que deseja buscar:");
                                int ranking = int.Parse(Console.ReadLine());
                                bool encontrado = buscarBandaPorRanking(listaBandas, ranking);
                                if (!encontrado)
                                {
                                    Console.WriteLine("Banda Não Encontrada");
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
                    break;
                case 4:
                    Console.Write("Digite o nome da banda que deseja atualizar:");
                    string nomeBandaAtualizar = Console.ReadLine();
                    bool atualizado = atualizarBanda(listaBandas, nomeBandaAtualizar);
                    Console.WriteLine(atualizado == true ? "Banda atualizada com sucesso!" : "Banda Não Encontrada");
                    break;
                case 5:
                    Console.Write("Digite o nome da banda que deseja remover:");
                    string nomeBandaRemover = Console.ReadLine();
                    bool removido = removerBanda(listaBandas, nomeBandaRemover);
                    if (removido)
                    {
                        Console.WriteLine("Banda removida com sucesso!");
                    }
                    break;
                case 6:
                    carregarDados(listaBandas, nomeArquivo);
                    break;
                case 0:
                    salvarDados(listaBandas, nomeArquivo);
                    Console.Write("Saindo...");
                    break;
            }// fim switch
            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        } while (opcao != 0);

    }// fim main

}
