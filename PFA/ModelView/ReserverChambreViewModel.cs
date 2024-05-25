using System.ComponentModel.DataAnnotations;

namespace PFA.ModelView
{
    public class ReserverChambreViewModel
    {
        public int HotelId { get; set; }
        public int UserId { get; set; }
    
        [Required]
        public int RoomId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateReservation { get; set; }
    }
}
