using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViagem.Models
{
    [Table("Viagem")]
    public class Viagem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o titulo da Viagem")]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a Descrição da Viagem")]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)")] 
        public decimal Valor { get; set; }

        public DateTime DataPartida { get; set; }
    }
}
