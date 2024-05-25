using System.ComponentModel.DataAnnotations;

namespace PFA.ModelView
{
    public class PaymentViewModel
    {
        public int ReservationId { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string ExpiryDate { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string CVV { get; set; }

		public int Montant { get; set; }
		public DateTime DatePaiment { get; set; }
		public bool IsPaid { get; set; }

	}
}
