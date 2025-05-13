using CQRS_Sample.Domain.Models.SomeModels;
using CQRS_Sample.Persistence.Command.Persistence;
using SIMA.Framework.Infrastructure.Data;

namespace CQRS_Sample.Persistence.Command.Repositories.SomeModels;

public class SomeModelCommandRepository : Repository<SomeModel>, ISomeModelCommandRepository
{
    public SomeModelCommandRepository(CommandDbContext dbContext) : base(dbContext)
    {
        
    }
}