using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRestaurante.Models.Dto
{
    public class TaxaEntregaDto
    {
        public int Id { get; set; }

        public string NomeBairro { get; set; }

        public decimal ValorEntrega { get; set; }

        public int TempoEntrega { get; set; }
    }
}
