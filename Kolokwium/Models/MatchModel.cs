using Kolokwium.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kolokwium.Models;

public class MatchModel
{
    public MatchModel()
    {
    }

    public MatchModel(IEnumerable<Team> teams, IEnumerable<Game> games)
    {
        AvailableTeams = new SelectList(teams, "Id", "TeamName");
        AvailableGames = new SelectList(games, "Id", "GameName");
    }

    public SelectList AvailableTeams { get; set; }
    public SelectList AvailableGames { get; set; }

    public Match PlayedMatch { get; set; }
}