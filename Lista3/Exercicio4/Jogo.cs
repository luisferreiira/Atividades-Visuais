using System;

namespace Exercicio4
{

    /*
     Crie uma classe jogos: 
     título (30 letras), console (15 letras), ano, ranking e empréstimo.

     O campo empréstimo é uma classe data que por sua vez, possui os campos:
        data, nomePessoa, emprestado (S/N)

     */
    public class Jogo
    {
        public string titulo;
        public string console;
        public int ano;
        public int ranking;
        public Emprestimo emprestimo = new Emprestimo(); // cria um obj com valores padrões, nunca é null
    }

    public class Emprestimo
    {
        public string nomePessoa;
        public DateTime dataEmprestimo;
        public bool emprestado;

    }
}