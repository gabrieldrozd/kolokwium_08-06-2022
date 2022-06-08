using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Entities;

public class Match
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Location { get; set; }

    // Team Foreign
    public Guid? FirstTeamId { get; set; }
    public virtual Team FirstTeam { get; set; }
    public Guid? SecondTeamId { get; set; }
    public virtual Team SecondTeam { get; set; }

    public Guid? GameId { get; set; }
    public virtual Game GameType { get; set; }

    public string MatchResult { get; set; }

    public bool IsCancelled { get; set; }

    public Guid? WinnerTeamId { get; set; }
    public virtual Team WinnerTeam { get; set; }
}