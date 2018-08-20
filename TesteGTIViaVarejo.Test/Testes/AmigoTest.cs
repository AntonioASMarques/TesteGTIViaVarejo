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
    public class AmigoTest
    {
        [TestMethod]
        public void APartirdaListaAmigosA_VerificaSeExistemAmigos_QuandoVisitoAmigoZ()
        {
            //arrange
            var amigoNomeZ = "Amigo Z";
            var amigoZ = new Amigo(10, amigoNomeZ, new Localizacao(0, 0));

            var amigosLista = UtilTestes.IniciaListaAmigos_A();
            amigosLista.Add(amigoZ);

            //act
            amigoZ.nome = amigoNomeZ;

            //assert
            Assert.IsTrue(amigosLista.Count > 1);
            Assert.IsTrue(amigosLista.Exists(x => x.nome == amigoNomeZ));
        }

        [TestMethod]
        public void TesteVisitaAmigo()
        {
            //arrange
            var nomeAmigoVisitado = "Amigo Marques";
            var amigosLista = UtilTestes.IniciaListaAmigos_A();
            amigosLista.Add(new Amigo(amigosLista.Count + 1, nomeAmigoVisitado, new Localizacao(25, 18)));

            //act
            var visitingAmigo = new AmigoNegocio(amigosLista).VisitaAmigo(nomeAmigoVisitado);

            //assert
            var expected = amigosLista.Find(_ => _.nome == nomeAmigoVisitado);
            var expectedNome = expected.nome;

            Assert.IsTrue(expectedNome == visitingAmigo.nome);
        }
    }
}
