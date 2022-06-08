using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Entities;

public class Game
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string GameName { get; set; }
}