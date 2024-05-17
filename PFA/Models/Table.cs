namespace AuthSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Numéro { get; set; }
        public int Nbr_Personnes { get; set; }
        public bool libre { get; set; }

        public Reservation? Reservation { get; set; }
        public int ReservationId { get; set; }
    }
}
