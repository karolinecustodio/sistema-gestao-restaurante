﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRestaurante.Models.Dto
{
    public class AnaliseDadosDto
    {
        public int ProdutoMaisVendidoId { get; set; }
        public int ProdutoMenosVendidoId { get; set; }
        public int QuantidadeProdutoMaisVendido { get; set; }
        public int QuantidadeProdutoMenosVendido { get; set; }
        public decimal TicketMedio { get; set; }
    }
}