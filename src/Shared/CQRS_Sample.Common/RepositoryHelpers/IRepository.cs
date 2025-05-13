using CQRS_Sample.Common.EntityHelpers;

namespace SIMA.Framework.Core.Repository;

public interface IRepository<T> where T : BaseEntity
{
    Task Add(T entity);
    void Remove(T entity);
}
