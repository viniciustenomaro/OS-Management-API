using System;
using System.ComponentModel.DataAnnotations;

namespace API.Data.VO
{
    public class PessoaVO
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
    }
}
