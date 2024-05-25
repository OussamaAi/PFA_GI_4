using PFA.ModelView;

namespace PFA.Visite
{
    public interface IVisitService
    {
        Task TrackVisit(int endroitId);
        Task<List<VisitStatisticViewModel>> GetVisitStatistics();
        Task<UserInfoViewModel> GetUserInfo();
    }
}
