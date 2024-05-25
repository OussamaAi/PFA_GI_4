using PFA.Models;

namespace PFA.ModelView
{
    public class ModifierReservationChambreViewModel
    {
        public DateTime Date { get; set; }
        public string Etat { get; set; }
        public string PhotoPath { get; set; }
        public User user { get; set; }
    }
}
