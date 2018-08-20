using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteGTIViaVarejo.Lib.Entidades;

namespace TesteGTIViaVarejo.Lib.Negocio
{
    public class AmigoNegocio
    {
        private List<Amigo> _listaAmigos;
        private Amigo _amigoVisitado;        
        public AmigoNegocio(List<Amigo> listaAmigos)
        {
            _listaAmigos = listaAmigos;
        }
        //Método para verificar e retornar o amigo visitado.
        public Amigo VisitaAmigo(string nomeAmigo)
        {
            _amigoVisitado = _listaAmigos.FirstOrDefault(x => x.nome == nomeAmigo);

            if (_amigoVisitado == null)
                throw new Exception(string.Format("Amigo {0} não encontrado na sua lista de amigos. Tente novamente.", nomeAmigo));

            return _amigoVisitado;
        }
        //Método para cadastrar amigo.
        public List<Amigo> InserirAmigo(Amigo amigoInserir)
        {
            //Valida a regra de mais de um amigo não poder estar cadastrado na mesma localização.
            if (_listaAmigos.Any(x => x.localizacao.latitude == amigoInserir.localizacao.latitude && x.localizacao.longitude == amigoInserir.localizacao.longitude))
                throw new Exception("Impossível cadastrar: Latidute e Longitude já cadastrada para outro amigo. Tente novamente.");

            _listaAmigos.Add(amigoInserir);
            return _listaAmigos;
        }
        //Método para listar os amigos próximos.
        public List<ComparacaoLocalizacao> ListarAmigosProximos()
        {
            int intDiferencaLatitude = 0;
            int intDiferencaLongitude = 0;
            int intDiferencaTotal = 0;
            int intDiferencaAmigoVisitado = 0;

            List<ComparacaoLocalizacao> listaAmigosProximos = new List<ComparacaoLocalizacao>();

            foreach (var item in _listaAmigos.Where(x => x.nome != _amigoVisitado.nome))
            {
                intDiferencaLatitude = _amigoVisitado.localizacao.latitude - item.localizacao.latitude;
                intDiferencaLongitude = _amigoVisitado.localizacao.longitude - item.localizacao.longitude;
                intDiferencaTotal = (intDiferencaLatitude) + (intDiferencaLongitude);

                if (intDiferencaTotal < 0)
                    intDiferencaAmigoVisitado = intDiferencaTotal * -1;
                else
                    intDiferencaAmigoVisitado = intDiferencaTotal;

                ComparacaoLocalizacao comparacaoLocalizacao = new ComparacaoLocalizacao();
                comparacaoLocalizacao.id = item.id;
                comparacaoLocalizacao.nome = item.nome;
                comparacaoLocalizacao.localizacao = new Localizacao();
                comparacaoLocalizacao.localizacao.latitude = item.localizacao.latitude;
                comparacaoLocalizacao.localizacao.longitude = item.localizacao.longitude;
                comparacaoLocalizacao.diferencaLatitude = intDiferencaLatitude;
                comparacaoLocalizacao.diferencaLongitude = intDiferencaLongitude;
                comparacaoLocalizacao.diferencaTotal = intDiferencaTotal;
                comparacaoLocalizacao.diferencaDoAmigo = intDiferencaAmigoVisitado;

                listaAmigosProximos.Add(comparacaoLocalizacao);
            }

            //Ordena os amigos pela proximidade
            listaAmigosProximos = listaAmigosProximos.OrderBy(x => x.diferencaDoAmigo).ToList();

            return listaAmigosProximos;
        }
        public List<ComparacaoLocalizacao> ListarAmigosProximosTop3()
        {
            int intDiferencaLatitude = 0;
            int intDiferencaLongitude = 0;
            int intDiferencaTotal = 0;
            int intDiferencaAmigoVisitado = 0;

            List<ComparacaoLocalizacao> listaAmigosProximos = new List<ComparacaoLocalizacao>();

            foreach (var item in _listaAmigos.Where(x => x.nome != _amigoVisitado.nome))
            {
                intDiferencaLatitude = _amigoVisitado.localizacao.latitude - item.localizacao.latitude;
                intDiferencaLongitude = _amigoVisitado.localizacao.longitude - item.localizacao.longitude;
                intDiferencaTotal = (intDiferencaLatitude) + (intDiferencaLongitude);

                if (intDiferencaTotal < 0)
                    intDiferencaAmigoVisitado = intDiferencaTotal * -1;
                else
                    intDiferencaAmigoVisitado = intDiferencaTotal;

                ComparacaoLocalizacao comparacaoLocalizacao = new ComparacaoLocalizacao();
                comparacaoLocalizacao.id = item.id;
                comparacaoLocalizacao.nome = item.nome;
                comparacaoLocalizacao.localizacao = new Localizacao();
                comparacaoLocalizacao.localizacao.latitude = item.localizacao.latitude;
                comparacaoLocalizacao.localizacao.longitude = item.localizacao.longitude;
                comparacaoLocalizacao.diferencaLatitude = intDiferencaLatitude;
                comparacaoLocalizacao.diferencaLongitude = intDiferencaLongitude;
                comparacaoLocalizacao.diferencaTotal = intDiferencaTotal;
                comparacaoLocalizacao.diferencaDoAmigo = intDiferencaAmigoVisitado;

                listaAmigosProximos.Add(comparacaoLocalizacao);
            }

            //Ordena os  amigos pela proximidade trazendo somente os 3 mais próximos.
            listaAmigosProximos = listaAmigosProximos.OrderBy(x => x.diferencaDoAmigo).Take(3).ToList();

            return listaAmigosProximos;
        }
    }
}
