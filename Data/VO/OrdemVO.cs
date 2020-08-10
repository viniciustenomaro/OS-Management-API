using API.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace API.Data.VO
{
    public class OrdemVO
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public double Verba { get; set; }

        [NotMapped]
        public List<Pessoa> Contribuidores { get; set; }

    }
}
