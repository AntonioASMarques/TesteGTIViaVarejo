using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteGTIViaVarejo.Lib.Entidades;
using TesteGTIViaVarejo.Lib.Negocio;
using TesteGTIViaVarejo.Test.Util;

namespace TesteGTIViaVarejo.Test.Testes
{
    [TestClass]
    public class AmigosProximosTop3Test
    {
        [TestMethod]
        public void APartirDaListaPositiva_QuandoVisitoAmigoZeta_EntaoListaOsTop3Proximos()
        {
            //arrange
            const string amigoVisitado = "Amigo Zeta";
            var listaAmigo = UtilTestes.IniciaListaAmigos_B();

            Amigo objAmigo = new Amigo();
            objAmigo.id = listaAmigo.Count + 1;
            objAmigo.nome = amigoVisitado;
            objAmigo.localizacao = new Localizacao();
            objAmigo.localizacao.latitude = 33;
            objAmigo.localizacao.longitude = 31;

            listaAmigo.Add(objAmigo);

            var amigoNegocio = new AmigoNegocio(listaAmigo);
            amigoNegocio.VisitaAmigo(amigoVisitado);

            //act            
            var top3AmigosProximos = amigoNegocio.ListarAmigosProximosTop3();

            //assert
            Assert.AreEqual("Amigo K", top3AmigosProximos[0].nome);
            Assert.AreEqual("Amigo W", top3AmigosProximos[1].nome);
            Assert.AreEqual("Amigo Y", top3AmigosProximos[2].nome);
        }

        [TestMethod]
        public void APartirDeListaNegativa_QuandoVisitoAmigoZeta_EntaoListaOsTop3Proximos()
        {
            //arrange
            var amigoVisitado = "Amigo Zeta";
            var amigosListaLocalizacoesNegativas = UtilTestes.IniciaListaAmigos_LocalizacoesNegativas();

            Amigo objAmigoVisitado = new Amigo();
            objAmigoVisitado.id = amigosListaLocalizacoesNegativas.Count + 1;
            objAmigoVisitado.nome = amigoVisitado;
            objAmigoVisitado.localizacao = new Localizacao();
            objAmigoVisitado.localizacao.latitude = -40;
            objAmigoVisitado.localizacao.longitude = -50;

            amigosListaLocalizacoesNegativas.Add(objAmigoVisitado);

            var amigoNegocio = new AmigoNegocio(amigosListaLocalizacoesNegativas);
            amigoNegocio.VisitaAmigo(amigoVisitado);

            amigoNegocio.ListarAmigosProximosTop3();

            var msgError = "Esse amigo não está contido na lista: top3AmigosProximos";

            //act            
            var top3AmigosProximos = amigoNegocio.ListarAmigosProximosTop3();
            var amigosEsperados = amigosListaLocalizacoesNegativas.FindAll(_ => _.nome == "Amigo K" ||
                                                            _.nome == "Amigo W" ||
                                                            _.nome == "Amigo Y");

            //assert
            CollectionAssert.Contains(top3AmigosProximos, amigosEsperados[0], msgError);
            CollectionAssert.Contains(top3AmigosProximos, amigosEsperados[1], msgError);
            CollectionAssert.Contains(top3AmigosProximos, amigosEsperados[2], msgError);
        }
    }
}
