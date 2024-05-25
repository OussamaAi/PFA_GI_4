using AuthSystem.Models;

namespace PFA.Models
{
    public class Chambre
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Type { get; set; }
        public int Prix { get; set; }
        public bool Disponibilité { get; set; }

        public Hotel hotel { get; set; }
        public int HotelId { get; set; }

        public Reservation? reservation { get; set; }
        public int? ReservationId { get; set; }
    }

}

