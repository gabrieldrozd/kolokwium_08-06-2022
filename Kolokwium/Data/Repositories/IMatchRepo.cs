using Kolokwium.Entities;

namespace Kolokwium.Data.Repositories;

public interface IMatchRepo
{
    Task<IEnumerable<Team>> GetTeams();
    Task<IEnumerable<Game>> GetGames();
    Task<IEnumerable<Match>> GetMatches();
    Task<Match> AddMatch(Match match);
}