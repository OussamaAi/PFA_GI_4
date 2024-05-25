using System.ComponentModel.DataAnnotations;

namespace PFA.ModelView
{
    public class ReserverTableViewModel
    {
        public int RestaurantId { get; set; }
        public int TableId { get; set; }

        [Required]
        [Display(Name = "Date de réservation")]
        public DateTime DateReservation { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
