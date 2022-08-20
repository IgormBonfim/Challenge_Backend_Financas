using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Backend_Financas.Models
{
    [Table("TbDespesa")]
    public class Despesa
    {
        [Key]
        [Column("IdDespesa")]
        public int Id { get; set; }

        [Column("DescricaoDespesa")]
        [Required, MaxLength(255)]
        public string Descricao { get; set; }

        [Column("ValorDespesa")]
        [Required]
        public decimal Valor { get; set; }

        [Column("DataDespesa")]
        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("Categoria")]
        [Column(Order = 1)]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
