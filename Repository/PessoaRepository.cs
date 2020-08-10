using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
    public class PessoaRepository
    {
        private MySqlContext _context { get; set; }

        public PessoaRepository(MySqlContext context)
        {
            _context = context;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            try
            {
                pessoa.Id = Guid.NewGuid().ToString();
                pessoa.Data = DateTime.Now;
                pessoa.Data.ToShortDateString();
                _context.Pessoa.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pessoa;
        }

        public void JoinOrdem(string pessoaId, string ordemId, int tempo)
        {
            try
            {
                PessoaOrdem pesOrd = new PessoaOrdem
                {
                    Id = Guid.NewGuid().ToString(),
                    OrdemId = ordemId,
                    PessoaId = pessoaId,
                    Tempo = tempo
                };

                _context.PessoaOrdem.Add(pesOrd);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pessoa> FindAll()
        {
            return _context.Pessoa.ToList();
        }

        public Pessoa FindById(string id)
        {
            return _context.Pessoa.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Pessoa Update(Pessoa pessoa)
        {
            if (!Exists(pessoa.Id)) return new Pessoa();

            var result = _context.Pessoa.SingleOrDefault(b => b.Id == pessoa.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public void Delete(string id)
        {
            var result = _context.Pessoa.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                {
                    _context.Pessoa.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Exists(string id)
        {
            return _context.Pessoa.Any(p => p.Id.Equals(id));
        }
    }
}
