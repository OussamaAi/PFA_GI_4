using PFA.Models;

namespace AuthSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Etat { get; set; }

        public User user { get; set; }
        public int UserId { get; set; }


        public IList<Paiment> paiments { get; set; }

        public IList<Chambre> chambres { get; set; }

        public IList<Table> tables { get; set; }

    }
}
