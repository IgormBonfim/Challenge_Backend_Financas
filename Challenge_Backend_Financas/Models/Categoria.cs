using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Backend_Financas.Models
{
    [Table("tbCategoria")]
    public class Categoria
    {
        [Key]
        [Column("IdCategoria")]
        public int Id { get; set; }

        [Column("NomeCategoria")]
        [Required, MaxLength(15)]
        public string NomeCategoria { get; set; }
    }
}
