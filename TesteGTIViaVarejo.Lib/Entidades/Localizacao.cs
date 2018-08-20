using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGTIViaVarejo.Lib.Entidades
{
    public class Localizacao
    {
        // 1. Atributos da classe
        public int latitude { get; set; }
        public int longitude { get; set; }

        // 2. Métodos construtores
        public Localizacao() { }

        public Localizacao(int latitude, int longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
