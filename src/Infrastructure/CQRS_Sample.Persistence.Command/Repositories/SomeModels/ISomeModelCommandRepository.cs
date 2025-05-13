using CQRS_Sample.Domain.Models.SomeModels;
using SIMA.Framework.Core.Repository;

namespace CQRS_Sample.Persistence.Command.Repositories.SomeModels;

public interface ISomeModelCommandRepository : IRepository<SomeModel>
{
}
