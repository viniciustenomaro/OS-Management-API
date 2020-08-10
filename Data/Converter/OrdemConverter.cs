using System;
using System.Collections.Generic;
using System.Linq;
using API.Data.Adapter;
using API.Data.VO;
using API.Model;

namespace API.Data.Converter
{
    public class OrdemConverter : IParser<OrdemVO, Ordem>, IParser<Ordem, OrdemVO>
    {
        public Ordem Parse(OrdemVO origin)
        {
            if (origin == null) return null;
            return new Ordem
            {
                Id = origin.Id,
                Numero = origin.Numero,
                Descricao = origin.Descricao,
                Verba = origin.Verba,
                Contribuidores = origin.Contribuidores
            };
        }

        public OrdemVO Parse(Ordem origin)
        {
            if (origin == null) return null;
            return new OrdemVO
            {
                Id = origin.Id,
                Numero = origin.Numero,
                Descricao = origin.Descricao,
                Verba = origin.Verba,
                Contribuidores = origin.Contribuidores
            };
        }

        public List<Ordem> ParseList(List<OrdemVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<OrdemVO> ParseList(List<Ordem> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
