using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Entities;

public class Team
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string TeamName { get; set; }
}