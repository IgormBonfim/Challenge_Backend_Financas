using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Backend_Financas.Models
{
    [Table("tbUsuario")]
    public class Usuario
    {
        [Key]
        [Column("IdUsuario")]
        public int Id { get; set; }

        [Column("emailUsuario")]
        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Column("senhaUsuario")]
        [Required, MaxLength(50)]
        public string Senha { get; set; }
    }
}
