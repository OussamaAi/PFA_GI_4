using Microsoft.AspNetCore.Mvc;
using PFA.Visite;

public class VisitController : Controller
{
    private readonly IVisitService _visitService;

    public VisitController(IVisitService visitService)
    {
        _visitService = visitService;
    }

    public async Task<IActionResult> TrackVisit(int endroitId)
    {
        int clientId = int.Parse(HttpContext.Session.GetString("Id"));

        await _visitService.TrackVisit(endroitId);

        return RedirectToAction("Index", "AfficherStatistique");
    }
}
