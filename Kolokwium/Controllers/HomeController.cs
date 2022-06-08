using System.Diagnostics;
using Kolokwium.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Models;

namespace Kolokwium.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMatchRepo _matchRepo;

    public HomeController(ILogger<HomeController> logger, IMatchRepo matchRepo)
    {
        _logger = logger;
        _matchRepo = matchRepo;
    }

    public async Task<IActionResult> Index()
    {
        var matches = await _matchRepo.GetMatches();
        return View(matches);
    }
    
    public async Task<IActionResult> Add()
    {
        var teams = await _matchRepo.GetTeams();
        var games = await _matchRepo.GetGames();
        var model = new MatchModel(teams, games);
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(MatchModel matchModel)
    {
        var result = await _matchRepo.AddMatch(matchModel.PlayedMatch);

        return result != null ? RedirectToAction("Index") : Error();
    }

    public async Task<IActionResult> Remove(Guid id)
    {
        var result = await _matchRepo.DeleteMatch(id);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}