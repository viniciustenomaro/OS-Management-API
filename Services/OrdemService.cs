using API.Data.Converter;
using API.Data.VO;
using API.Repository;
using System.Collections.Generic;

namespace API.Services
{
    public class OrdemService
    {
        private readonly OrdemRepository _repository;

        private readonly OrdemConverter _converter;

        public OrdemService(OrdemRepository repository)
        {
            _repository = repository;
            _converter = new OrdemConverter();
        }

        public OrdemVO FindById(string id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<OrdemVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public OrdemVO Update(OrdemVO ordem)
        {
            var entity = _converter.Parse(ordem);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }

        public OrdemVO Create(OrdemVO ordem)
        {
            var entity = _converter.Parse(ordem);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }

        public void Delete(int numero)
        {
            _repository.Delete(numero);
        }

        public void AddPessoa(string ordemId, string pesId, int time)
        {
            _repository.AddPessoa(ordemId, pesId, time);
        }
    }
}
