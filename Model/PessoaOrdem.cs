using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class PessoaOrdem
    {
        [Key]
        public string Id { get; set; }

        public Pessoa Pessoa { get; set; }

        [Required]
        public string PessoaId { get; set; }

        public Ordem Ordem { get; set; }

        [Required]
        public string OrdemId { get; set; }

        [Required]
        public int Tempo { get; set; }
    }
}
