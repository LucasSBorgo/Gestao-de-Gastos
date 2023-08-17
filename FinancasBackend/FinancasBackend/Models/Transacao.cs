using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasBackend.Models
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        public int id { get; set; }

        [Column("descricao")]
        [MaxLength(200)]
        public string descricao { get; set; }

        [Required]
        [Column("data")]
        public DateTime data { get; set; }

        [Required]
        [Precision(14,2)]
        [Column("valor")]
        public decimal valor { get; set; }

        [Required]
        [Column("tipo_inclusao")]
        [MaxLength(1)]
        public string tipo_inclusao { get; set; }

        [Required]
        [Column("modalidade")]
        public int modalidade { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario.id))]
        [Column("es_usuario")]
        public int es_usuario { get; set; }

        [Required]
        [ForeignKey(nameof(Conta.id))]
        [Column("es_conta")]
        public int es_conta { get; set; }
    }
}
