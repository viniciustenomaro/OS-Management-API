using API.Context;
using API.Data.Converter;
using API.Data.VO;
using API.Model;
using API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class PessoaService
    {
        private readonly PessoaRepository _repository;

        private readonly PessoaConverter _converter;

        public PessoaService(PessoaRepository repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }

        public PessoaVO Create(PessoaVO pessoa)
        {
            var entity = _converter.Parse(pessoa);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public void JoinOrdem(string pessoaId, string ordemId, int tempo)
        {
            _repository.JoinOrdem(pessoaId, ordemId, tempo);
        }

        public List<PessoaVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PessoaVO FindById(string id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PessoaVO Update(PessoaVO pessoa)
        {
            var entity = _converter.Parse(pessoa);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }
    }
}
