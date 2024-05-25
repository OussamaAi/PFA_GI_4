
namespace AuthSystem.Models
{
    public class Paiment
    {
        public int Id { get; set; } 
        public int Montant { get; set; }
        public DateTime DatePaiment { get; set; }
        public bool IsPaid { get; set; }
        public string NumeroDeCarte { get; set; }
        public DateTime DateExpiration {  get; set; }
        public string CVV {  get; set; }
        public Reservation? reservation { get; set; }
        public int ReservationId { get; set; }

    }
}
