using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteGTIViaVarejo.Lib.Entidades
{
    public class Enumeradores
    {
        public enum Menu
        {
            [Description("0 - Vizualizar amigos cadastrados")]
            VizualizarAmigosCadastrados = 0,
            [Description("1 - Vizualizar amigos próximos em ordem de proximidade")]
            VizualizarAmigosProximos = 1,
            [Description("2 - Vizualizar amigos próximos em ordem de proximidade (top 3)")]
            VizualizarTop3AmigosProximos = 2,
            [Description("3 - Inserir novo amigo")]
            InserirAmigo = 3,
            [Description("4 - Encerrar aplicação")]
            Encerrar = 4,
        }
    }
}
