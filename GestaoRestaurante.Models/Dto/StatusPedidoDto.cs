using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRestaurante.Models.Dto
{
    public enum StatusPedidoDto
    {
        [Description("Novo")]
        Novo,

        [Description("Em Preparo")]
        EmPreparo,

        [Description("Aguardando Retirada")]
        AguardandoRetirada,

        [Description("Entregue")]
        Entregue,

        [Description("Cancelado")]
        Cancelado,

        [Description("A Caminho")]
        ACaminho
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }
    }
}
