using API.Context;
using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class OrdemRepository
    {
        private MySqlContext _context;

        public OrdemRepository(MySqlContext context)
        {
            _context = context;
        }

        public Ordem FindById(string id)
        {
            var ordem = _context.Ordem.SingleOrDefault(p => p.Id.Equals(id));

            if (ordem == null) return new Ordem();

            var pessoas = _context.Pessoa.ToList();

            var linq = (from pes in pessoas
                        join pesord in _context.PessoaOrdem on pes.Id equals pesord.PessoaId
                        where pesord.OrdemId == id
                        select pes).ToList();

            ordem.Contribuidores = new List<Pessoa>();

            foreach(Pessoa pes in linq)
            {
                ordem.Contribuidores.Add(pes);
            }

            return ordem;
        }

        public List<Ordem> FindAll()
        {
            var ordens = _context.Ordem.ToList().OrderBy(p => p.Numero);

            List<Ordem> ordemResult = new List<Ordem>();

            var pessoas = _context.Pessoa.ToList();

            foreach (Ordem ordem in ordens)
            { 
                var linq = (from pes in pessoas
                            join pesord in _context.PessoaOrdem on pes.Id equals pesord.PessoaId
                            where pesord.OrdemId == ordem.Id
                            select pes).ToList();

                ordem.Contribuidores = new List<Pessoa>();

                foreach (Pessoa pes in linq)
                {
                    ordem.Contribuidores.Add(pes);
                }

                ordemResult.Add(ordem);
            }

            return ordemResult;
        }

        public Ordem Update(Ordem ordem)
        {
            if (!Exists(ordem.Id)) return new Ordem();

            var result = _context.Ordem.SingleOrDefault(b => b.Id == ordem.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(ordem);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public Ordem Create(Ordem ordem)
        {
            var result = _context.Ordem.Any(p => p.Numero.Equals(ordem.Numero));

            if (result == true) return null;

            try
            {
                ordem.Id = Guid.NewGuid().ToString();
                _context.Ordem.Add(ordem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ordem;
        }

        public void Delete(int numero)
        {
            var result = _context.Ordem.SingleOrDefault(p => p.Numero.Equals(numero));

            try
            {
                if (result != null)
                {
                    _context.Ordem.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddPessoa(string ordemId, string pesId, int time)
        {
            var ord = _context.Ordem.Any(p => p.Id == ordemId);
            var pes = _context.Pessoa.Any(p => p.Id == pesId);

            if (ord == false || pes == false ) return;

            PessoaOrdem pesOrd = new PessoaOrdem() 
            {
                Id = Guid.NewGuid().ToString(),
                OrdemId = ordemId,
                PessoaId = pesId,
                Tempo = time 
            };

            _context.PessoaOrdem.Add(pesOrd);
            _context.SaveChanges();
        }

        private bool Exists(string id)
        {
            return _context.Ordem.Any(p => p.Id.Equals(id));
        }
    }
}
