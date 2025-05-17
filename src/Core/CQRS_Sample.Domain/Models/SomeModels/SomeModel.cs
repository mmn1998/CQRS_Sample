using CQRS_Sample.Common.EntityHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS_Sample.Domain.Models.SomeModels;

public class SomeModel : BaseEntity
{
    public SomeModel(CreateSomeModelArg arg)
    {
        Id = arg.Id;
        Name = arg.Name;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public long Id { get; private set; }
    public string? Name { get; private set; }
    public static SomeModel Create(CreateSomeModelArg arg)
    {
        return new SomeModel(arg);
    }
    public void Modify(SomeModel arg)
    {
        Name = arg.Name;
    }
}