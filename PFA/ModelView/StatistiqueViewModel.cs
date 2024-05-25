using AuthSystem.Models;
using PFA.Models;

namespace PFA.ModelView
{
    public class StatistiqueViewModel
    {

        public List<VisitStatisticViewModel> VisitStatistics { get; set; }
        public string PhotoPath { get; set; }
        public User user { get; set; }

    }
}
