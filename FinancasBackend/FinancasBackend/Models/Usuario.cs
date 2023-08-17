using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasBackend.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(100)]
        public string nome { get; set; }

        [Required]
        [Column("idade")]
        public int idade { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(100)]
        public string email { get; set; }
    }
}
