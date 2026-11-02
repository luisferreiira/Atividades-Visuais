using System;

namespace Exercicio5 {

    public class Gado {
        public int codigo;
        public double leite;
        public double alim;
        public Nascimento nasc = new Nascimento();
        public bool abate;
    }

    public class Nascimento {
        public int mes;
        public int ano;
    }
}