using System;
using System.Collections.Generic;
using System.Linq;
using API.Data.Adapter;
using API.Data.VO;
using API.Model;

namespace API.Data.Converter
{
    public class PessoaConverter : IParser<PessoaVO, Pessoa>, IParser<Pessoa, PessoaVO>
    {
        public Pessoa Parse(PessoaVO origin)
        {
            if (origin == null) return null;
            return new Pessoa
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Data = origin.Data,
                Salario = origin.Salario,
                Hh = origin.Hh,
                Acesso = origin.Acesso
            };
        }

        public PessoaVO Parse(Pessoa origin)
        {
            if (origin == null) return null;
            return new PessoaVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Data = origin.Data,
                Salario = origin.Salario,
                Hh = origin.Hh,
                Acesso = origin.Acesso
            };
        }

        public List<Pessoa> ParseList(List<PessoaVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PessoaVO> ParseList(List<Pessoa> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
