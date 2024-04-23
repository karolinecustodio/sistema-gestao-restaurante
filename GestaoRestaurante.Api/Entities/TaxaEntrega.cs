using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoRestaurante.Api.Entities
{
    public class TaxaEntrega
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string NomeBairro { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorEntrega { get; set; }

        public int TempoEntrega { get; set; }
    }
}
