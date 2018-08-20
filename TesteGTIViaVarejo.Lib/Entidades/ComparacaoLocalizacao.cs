using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGTIViaVarejo.Lib.Entidades
{
    public class ComparacaoLocalizacao : Amigo
    {
        // 1. Atributos da classe
        public int diferencaLatitude { get; set; }
        public int diferencaLongitude { get; set; }
        public int diferencaTotal { get; set; }
        public int diferencaDoAmigo { get; set; }

        // 2. Métodos construtores
        public ComparacaoLocalizacao() { }
        public ComparacaoLocalizacao(int id, String nome, int latitude, int longitude, int diferencaLatitude, int diferencaLongitude, int diferencaTotal, int diferencaDoAmigo)
        {
            this.id = id;
            this.nome = nome;            
            this.localizacao.latitude = latitude;
            this.localizacao.longitude = longitude;
            this.diferencaLatitude = diferencaLatitude;
            this.diferencaLongitude = diferencaLongitude;
            this.diferencaTotal = diferencaTotal;
            this.diferencaDoAmigo = diferencaDoAmigo;
        }
    }
}
