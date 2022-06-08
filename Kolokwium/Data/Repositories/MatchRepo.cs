using Kolokwium.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Data.Repositories;

public class MatchRepo : IMatchRepo
{
    private readonly Context _context;

    public MatchRepo(Context context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Team>> GetTeams()
    {
        var teams = await _context.Teams.ToListAsync();
        return teams;
    }

    public async Task<IEnumerable<Game>> GetGames()
    {
        var games = await _context.Games.ToListAsync();
        return games;
    }

    public async Task<IEnumerable<Match>> GetMatches()
    {
        var matches = await _context.Matches
            .Include(x => x.GameType)
            .Include(x => x.FirstTeam)
            .Include(x => x.SecondTeam)
            .Include(x => x.WinnerTeam)
            .ToListAsync();
        
        return matches;
    }

    public async Task<Match> AddMatch(Match match)
    {
        match.Id = Guid.NewGuid();
        var entity = await _context.Matches.AddAsync(match);
        var result = await _context.SaveChangesAsync() > 0;

        return result ? entity.Entity : null;
    }

    public async Task<bool> DeleteMatch(Guid id)
    {
        var match = await _context.Matches.FirstOrDefaultAsync(x => x.Id == id);

        if (match != null) _context.Matches.Remove(match);

        var result = await _context.SaveChangesAsync() > 0;

        return result;
    }
}