using Microsoft.EntityFrameworkCore;
using PFA.Context;
using PFA.Models;
using PFA.ModelView;

namespace PFA.Visite
{
    public class VisitService:IVisitService
    {
        private readonly MyContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VisitService(MyContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task TrackVisit(int clientId, int endroitId)
        {
            var visit = new Visit
            {
                ClientId = clientId,
                EndroitId = endroitId,
                VisitDate = DateTime.Now
            };

            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VisitStatisticViewModel>> GetVisitStatistics()
        {
            var visitsWithEndroits = await _context.Visits
                .Include(v => v.Endroit)
                .ToListAsync();

            var statistics = visitsWithEndroits
                .GroupBy(v => v.Endroit)
                .Select(group => new VisitStatisticViewModel
                {
                    EndroitId = group.Key.Id,
                    NomEndroit = group.Key.NomEndroit,
                    VisitCount = group.Count()
                })
                .ToList();

            return statistics;
        }

        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var clientIdString = _httpContextAccessor.HttpContext.Session.GetString("Id");
            if (int.TryParse(clientIdString, out int Id))
            {
                var user = await _context.Users.FindAsync(Id);
                if (user != null)
                {
                    return new UserInfoViewModel
                    {
                        user = user,
                        PhotoPath = user.Photo
                    };
                }
            }
            throw new InvalidOperationException("Client ID is not found in the session.");
        }

        public Task TrackVisit(int endroitId)
        {
            throw new NotImplementedException();
        }
    }
}
