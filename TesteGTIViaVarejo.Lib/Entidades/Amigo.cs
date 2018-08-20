using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGTIViaVarejo.Lib.Entidades
{
    public class Amigo
    {
        // 1. Atributos da classe
        public int id { get; set; }
        public string nome { get; set; }
        public Localizacao localizacao { get; set; }

        // 2. Métodos construtores
        public Amigo() { }
        public Amigo(int id, string nome, Localizacao localizacao)
        {
            this.id = id;
            this.nome = nome;
            this.localizacao = localizacao;
        }
    }
}
