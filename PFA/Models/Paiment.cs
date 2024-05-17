
namespace AuthSystem.Models
{
    public class Paiment
    {
        public int Id { get; set; }
        public string TypePaiment { get; set; }
        public int Montant { get; set; }
        public DateTime DatePaiment { get; set; }

        public Reservation? reservation { get; set; }
        public int ReservationId { get; set; }

    }
}
