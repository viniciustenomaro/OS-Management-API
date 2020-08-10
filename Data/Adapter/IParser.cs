using System.Collections.Generic;

namespace API.Data.Adapter
{
    //O é a ORIGEM e D o DESTINO
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
