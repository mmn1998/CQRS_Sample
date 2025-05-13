using CQRS_Sample.Common.EntityHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS_Sample.Domain.Models.SomeModels;

public class SomeModel : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public long Id { get; set; }
    public string? Name { get; set; }
}
