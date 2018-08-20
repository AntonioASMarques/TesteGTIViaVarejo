using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TesteGTIViaVarejo.Lib.Entidades;
using TesteGTIViaVarejo.Lib.Negocio;
using static TesteGTIViaVarejo.Lib.Entidades.Enumeradores;

namespace TesteGTIViaVarejo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Popula a lista de amigos com os amigos iniciais.
            List<Amigo> lstAmigos = new List<Amigo>();
            lstAmigos = InicializarListagemAmigos();

            //Chama método que monta e exibe o menú principal;
            ExibirMenuPrincipal(lstAmigos);
        }

        //Método para retornar a descrição de um enum.
        public static string RetornaDescricaoEnum(Enum value)
        {
            try
            {
                FieldInfo objfi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])objfi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        //Método para escrever o menú de opções.
        protected static void ListaMenu()
        {
            Console.WriteLine("\nSelecione a funcionalidade a ser executada:\n");

            foreach (Menu item in Enum.GetValues(typeof(Menu)))
            {
                Console.WriteLine(RetornaDescricaoEnum(item));
            }
        }

        //Método que retorna a lista inicial de amigos.
        private static List<Amigo> InicializarListagemAmigos()
        {
            var amigosLista = new List<Amigo>{
                new Amigo(1,"Rafael Medeiros Santana", new Localizacao(-10, 80)),
                new Amigo(2,"Marcela Camargo Oliveira", new Localizacao(12, 29)),
                new Amigo(3,"Marcos Eduardo Pereira", new Localizacao(-22, 44)),
                new Amigo(4,"Joseane Beatriz Menezes", new Localizacao(25, 60)),
                new Amigo(5,"Gustavo Alves Amaral", new Localizacao(-2, 90)),
                new Amigo(6,"Samira Correia", new Localizacao(-45, 40)),
                new Amigo(7,"Rogerio Martins", new Localizacao(3, 25)),
                new Amigo(8,"Bianca Paulino", new Localizacao(-80, 20)),
                new Amigo(9,"Adriano Lobato", new Localizacao(75, -15)),
                new Amigo(10,"Milena Teles Delanina", new Localizacao(95, -45)),
            };
            return amigosLista;
        }

        //Método que processa a opção do menú selecionada pelo usuário
        private static void ProcessaOpcaoMenu(List<Amigo> lstAmigos, Menu opcaoMenu)
        {
            bool continua = true;

            //Verifica se a opção informada é válida

            switch (opcaoMenu)
            {
                case Menu.VizualizarAmigosProximos:
                    Console.Clear();
                    while (continua)
                    {
                        try
                        {
                            Console.WriteLine("Funcionalidade acessada: " + RetornaDescricaoEnum(opcaoMenu) + "\n");
                            ExibirListaDeAmigos(lstAmigos);

                            string nomeAmigoAVisitar;
                            string confirmaAmigoAVisitar;

                            Console.WriteLine("Informe o nome do amigo que está visitando:");
                            nomeAmigoAVisitar = Console.ReadLine();

                            Console.WriteLine(string.Format("Deseja realmente visitar o amigo: {0}? Tecle 'S' para sim e 'N' para não: ", nomeAmigoAVisitar));
                            confirmaAmigoAVisitar = Console.ReadLine();

                            while (confirmaAmigoAVisitar.ToUpper() != "S")
                            {
                                Console.WriteLine("Informe o nome do amigo que está visitando:");
                                nomeAmigoAVisitar = Console.ReadLine();

                                Console.WriteLine(string.Format("Deseja realmente visitar o amigo: {0}? Tecle 'S' para sim e 'N' para não: ", nomeAmigoAVisitar));
                                confirmaAmigoAVisitar = Console.ReadLine();
                            }

                            AmigoNegocio amigoNegocio = new AmigoNegocio(lstAmigos);
                            Amigo objAmigoVisitado = amigoNegocio.VisitaAmigo(nomeAmigoAVisitar);

                            var listagemAmigosProximos = amigoNegocio.ListarAmigosProximos();
                            ExibirListaDeAmigosProximos(listagemAmigosProximos, objAmigoVisitado);

                            continua = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    ExibirMenuPrincipal(lstAmigos);
                    break;
                case Menu.VizualizarTop3AmigosProximos:
                    Console.Clear();
                    while (continua)
                    {
                        try
                        {
                            Console.WriteLine("Funcionalidade acessada: " + RetornaDescricaoEnum(opcaoMenu) + "\n");
                            ExibirListaDeAmigos(lstAmigos);

                            string nomeAmigoAVisitar;
                            string confirmaAmigoAVisitar;

                            Console.WriteLine("Informe o nome do amigo que está visitando:");
                            nomeAmigoAVisitar = Console.ReadLine();

                            Console.WriteLine(string.Format("Deseja realmente visitar o amigo: {0}? Tecle 'S' para sim e 'N' para não: ", nomeAmigoAVisitar));
                            confirmaAmigoAVisitar = Console.ReadLine();

                            while (confirmaAmigoAVisitar.ToUpper() != "S")
                            {
                                Console.WriteLine("Informe o nome do amigo que está visitando:");
                                nomeAmigoAVisitar = Console.ReadLine();

                                Console.WriteLine(string.Format("Deseja realmente visitar o amigo: {0}? Tecle 'S' para sim e 'N' para não: ", nomeAmigoAVisitar));
                                confirmaAmigoAVisitar = Console.ReadLine();
                            }

                            AmigoNegocio amigoNegocio = new AmigoNegocio(lstAmigos);
                            Amigo objAmigoVisitado = amigoNegocio.VisitaAmigo(nomeAmigoAVisitar);

                            var listagemAmigosProximos = amigoNegocio.ListarAmigosProximosTop3();
                            ExibirListaDeAmigosProximos(listagemAmigosProximos, objAmigoVisitado);

                            continua = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    ExibirMenuPrincipal(lstAmigos);
                    break;

                case Menu.VizualizarAmigosCadastrados:
                    Console.Clear();
                    while (continua)
                    {
                        try
                        {
                            Console.WriteLine("Funcionalidade acessada: " + RetornaDescricaoEnum(opcaoMenu) + "\n");
                            ExibirListaDeAmigos(lstAmigos);
                            continua = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    ExibirMenuPrincipal(lstAmigos);
                    break;
                case Menu.InserirAmigo:
                    Console.Clear();
                    while (continua)
                    {
                        try
                        {
                            Console.WriteLine("Funcionalidade acessada: " + RetornaDescricaoEnum(opcaoMenu) + "\n");

                            Console.WriteLine("Informe o nome do amigo:");
                            string _nomeAmigo = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Informe a latitude:");
                            int _latitudeAmigo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("");
                            Console.WriteLine("Infome a Longitude:");
                            int _longitudeAmigo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("");

                            var amigoNegocio = new AmigoNegocio(lstAmigos);
                            var amigoInserir = new Amigo(lstAmigos.Count() + 1, _nomeAmigo, new Localizacao(_latitudeAmigo, _longitudeAmigo));
                            lstAmigos = amigoNegocio.InserirAmigo(amigoInserir);

                            string strMensagem = "Amigo " + _nomeAmigo + " cadastrado com sucesso!";
                            Console.WriteLine(strMensagem);
                            Console.WriteLine(string.Concat(Enumerable.Repeat("-", strMensagem.Length)));
                            Console.WriteLine("");

                            continua = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    ExibirMenuPrincipal(lstAmigos);
                    break;
                case Menu.Encerrar:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opção inválida no Menu");
                    Console.WriteLine("----------------");
                    break;
            }
        }

        //Método para exibir a lista de amigos cadastrados.
        private static void ExibirListaDeAmigos(List<Amigo> listaAmigos)
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("Lista de amigos cadastrados:");
            Console.WriteLine("======================================================================");
            Console.WriteLine("");

            foreach (var amigo in listaAmigos)
            {
                Console.WriteLine(string.Format("Nome: {0} | Lat: {1} | Lon: {2}",
                    amigo.nome.PadRight(30, ' '),
                    amigo.localizacao.latitude,
                    amigo.localizacao.longitude
                ));
            }
            Console.WriteLine("");
        }

        //Método para exibir a lista de amigos próximos.
        private static void ExibirListaDeAmigosProximos(List<ComparacaoLocalizacao> listaAmigos, Amigo amigoVisitado)
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("Amigo visitado: {0}\tLat: {1}\tLon: {2}", amigoVisitado.nome,
                    amigoVisitado.localizacao.latitude, amigoVisitado.localizacao.longitude);
            Console.WriteLine("======================================================================");

            Console.WriteLine();
            Console.WriteLine("============== Amigos listados por ordem de proximidade ==============");

            for (int i = 0; i < listaAmigos.Count; i++)
            {
                Console.WriteLine("{0}-{1} | Lat:{2} | Lon:{3} | difLat:{4} | difLon:{5} | difT:{6} | difAmigoVisitado:{7}", i + 1,
                    listaAmigos[i].nome.PadRight(31 - (i + 1).ToString().Length, ' '),
                    listaAmigos[i].localizacao.latitude, listaAmigos[i].localizacao.longitude,
                    listaAmigos[i].diferencaLatitude, listaAmigos[i].diferencaLongitude, listaAmigos[i].diferencaTotal, listaAmigos[i].diferencaDoAmigo);
            }
            Console.WriteLine("======================================================================");
        }

        //Método para processar o menú principal.
        private static void ExibirMenuPrincipal(List<Amigo> lstAmigos)
        {
            //Chama o método para listar o menú de opções ao usuário.
            ListaMenu();

            //Captura a opção selecionada pelo usuário.
            Menu OpcaoMenuselecionada = ((Menu)Enum.Parse(typeof(Menu), Console.ReadLine().ToString(), true));

            //Processa a opção selecionada.
            ProcessaOpcaoMenu(lstAmigos, OpcaoMenuselecionada);
        }
    }
}
