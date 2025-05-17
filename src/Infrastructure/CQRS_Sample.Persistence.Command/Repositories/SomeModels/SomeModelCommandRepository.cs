using CQRS_Sample.Domain.Models.SomeModels;
using CQRS_Sample.Persistence.Command.Persistence;
using Microsoft.EntityFrameworkCore;
using SIMA.Framework.Infrastructure.Data;

namespace CQRS_Sample.Persistence.Command.Repositories.SomeModels;

public class SomeModelCommandRepository : Repository<SomeModel>, ISomeModelCommandRepository
{
    private readonly CommandDbContext _dbContext;

    public SomeModelCommandRepository(CommandDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SomeModel> GetById(long id)
    {
        return await _dbContext.SomeModels.FirstOrDefaultAsync(i => i.Id == id) ?? throw new KeyNotFoundException();
    }
}