using CadastroBandasConsoleApp2026;
using System;

class Program
{
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

    public static bool buscarBanda(List<Banda> listaBandas, string nomeBanda)
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
            if (listaBandas[i].nome.ToUpper().Contains(nomeBanda.ToUpper())) // Compare se os nomes são iguais
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
        }
        return false;
    }

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


    static int menu()
    {
        Console.WriteLine("=== SISTEMA DE CADASTRO DE BANDAS ===");
        Console.WriteLine("1 - Adicionar Banda");
        Console.WriteLine("2 - Mostrar Bandas");
        Console.WriteLine("3 - Buscar Banda");
        Console.WriteLine("4 - Atualizar Banda");
        Console.WriteLine("5 - Remover Banda"); 
        Console.WriteLine("0 - Salvar e Sair");
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
                    Console.WriteLine("\nInsira o nome da banda que deseja buscar:");
                    string nomeBanda = Console.ReadLine();
                    bool encontrado = buscarBanda(listaBandas, nomeBanda);
                    Console.WriteLine(encontrado == true ? "Banda Encontrada" : "Banda Não Encontrada");
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
                    Console.WriteLine(removido == true ? "Banda removida com sucesso!" : "Banda Não Encontrada");
                    break;
                case 0:
                    salvarDados(listaBandas, nomeArquivo);
                    Console.Write("Saindo...");
                    break;
            }// fim switch
            Console.ReadKey();
            Console.Clear();
        } while (opcao != 0);

    }// fim main

}
