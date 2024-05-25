using PFA.Models;

namespace AuthSystem.Models
{
    public class Hotel:Endroit
    {
              
        public int NbrCHambre { get; set; }
        public IList<Chambre>? Chambres { get; set; }
    }
}
