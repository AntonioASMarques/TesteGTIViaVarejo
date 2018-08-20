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
    public class AmigosProximosTest
    {
        [TestMethod]
        public void TesteAmigosProximos_1()
        {
            //arrange
            const string nomeAmigoVisitado = "Amigo Beta";
            var amigosLista = UtilTestes.IniciaListaAmigos_B();
            amigosLista.Add(new Amigo(amigosLista.Count + 1, nomeAmigoVisitado, new Localizacao(-1, -20)));
            var amigoNegocio = new AmigoNegocio(amigosLista);

            //act            
            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

            var AmigosProximos = amigoNegocio.ListarAmigosProximos();

            //assert
            Assert.AreEqual("Amigo A", AmigosProximos[0].nome);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteAmigosProximos_2()
        {
            //arrange
            string nomeAmigoVisitado = "Amigo Sigma";
            var amigosList = UtilTestes.IniciaListaAmigos_B();
            var amigoNegocio = new AmigoNegocio(amigosList);

            //act            
            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

        }

        [TestMethod]
        public void TesteAmigosProximos_3()
        {
            //arrange
            string nomeAmigoVisitado = "Amigo Beta";
            var amigosLista = UtilTestes.IniciaListaAmigos_B();
            amigosLista.Add(new Amigo(amigosLista.Count + 1, nomeAmigoVisitado, new Localizacao(25, 18)));

            //act
            var amigoNegocio = new AmigoNegocio(amigosLista);
            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

            var amigoProximo = amigoNegocio.ListarAmigosProximos()[0];

            //assert
            Assert.AreEqual("Amigo Z", amigoProximo.nome);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteAmigosProximos_4()
        {
            //arrange
            string nomeAmigoVisitado = "Amigo Beta";
            var amigosLista = UtilTestes.IniciaListaAmigos_C();
            var amigoNegocio = new AmigoNegocio(amigosLista);
            amigoNegocio.VisitaAmigo(nomeAmigoVisitado);

            //act
            var amigoProximo = amigoNegocio.ListarAmigosProximos().FirstOrDefault();

            //assert
            Assert.AreEqual("Amigo K", amigoProximo.nome);
        }
    }
}
