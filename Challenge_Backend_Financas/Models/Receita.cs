using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Backend_Financas.Models
{
    [Table("TbReceita")]
    public class Receita
    {
        [Key]
        [Column("IdReceita")]
        public int Id { get; set; }

        [Column("DescricaoReceita")]
        [Required, MaxLength(255)]
        public string Descricao { get; set; }

        [Column("ValorReceita")]
        [Required]
        public decimal Valor { get; set; }

        [Column("DataReceita")]
        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("Categoria")]
        [Column(Order = 1)]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
