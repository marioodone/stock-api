using FluentValidation;
using stock_api.Domain.Entities;
using System.Collections.Generic;

namespace stock_api.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;
        T Put<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);

        T Get(int id);

        IList<T> Get();
    }
}
