using CQRS_Sample.Domain.Models.SomeModels;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Sample.Persistence.Command.Persistence;

public class CommandDbContext : DbContext
{
    public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
    {

    }
    public DbSet<SomeModel> SomeModels { get; set; }
}
