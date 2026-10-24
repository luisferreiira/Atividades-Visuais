using System;

public class Banda
{
    public string nome;
    public string genero;
    public int integrantes;
    public int ranking;

    public static void addBanda(List<Banda> listaBandas)
    {
        Banda novaBanda = new Banda(); // Instancie uma nova Banda

        Console.Write("Nome: ");
        novaBanda.nome = Console.ReadLine();

        Console.Write("Gênero: ");
        novaBanda.genero = Console.ReadLine();

        Console.Write("Integrantes: ");
        novaBanda.integrantes = int.Parse(Console.ReadLine());

        Console.Write("Ranking: ");
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
                encontrado = true;
            }
        }
        return encontrado;
    }




    class Program
    {
        static void Main()
        {

            static int menu()
            {
                Console.WriteLine("=== SISTEMA DE CADASTRO DE BANDAS ===");
                Console.WriteLine("1 - Adicionar Banda");
                Console.WriteLine("2 - Mostrar Bandas");
                Console.WriteLine("3 - Buscar Banda");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                return int.Parse(Console.ReadLine());
            }

            int opcao = 0;

            // Declare e instancie a lista de bandas (List<Banda>)
            List<Banda> listaBandas = new List<Banda>();

            do
            {
                opcao = menu();
                switch (opcao)
                {
                    case 1:
                        addBanda(listaBandas);
                        break;
                    case 2:
                        mostrarBandas(listaBandas);
                        break;
                    case 3:
                        Console.WriteLine("\nInsira o nome da banda que deseja buscar:");
                        string nomeBanda = Console.ReadLine();
                        bool encontrado = buscarBanda(listaBandas, nomeBanda);
                        Console.WriteLine(encontrado == true ? "Banda Encontrada" : "Banda Não Encontrada");
                        break;
                    case 0:
                        Console.Write("Saindo...");
                        break;
                    default:
                        break;
                }
                Console.ReadKey(); // pausa
                Console.Clear();   // limpa a tela
            } while (opcao != 0);
        }
    }
}
