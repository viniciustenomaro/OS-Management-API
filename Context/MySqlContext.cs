using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Pessoa> Pessoa{ get; set; }
        public DbSet<Ordem> Ordem { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<PessoaOrdem> PessoaOrdem { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
    }
}
