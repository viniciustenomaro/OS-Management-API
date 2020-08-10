using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int Acesso { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public double Salario { get; set; }

        [Required]
        public double Hh { get; set; }

        [NotMapped]
        public double Custo { get; set; }
    }
}
