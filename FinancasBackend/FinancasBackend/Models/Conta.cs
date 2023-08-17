using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasBackend.Models
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column("saldo")]
        [Precision(14, 2)]
        public decimal saldo { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario.id))]
        [Column("es_usuario")]
        public int es_usuario{ get; set; }
    }
}
