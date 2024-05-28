namespace DataAccessObjects.DTO
{
    public class CustomBookingReservation
    {
        public int BookingReservationId { get; set; }

        public DateOnly? BookingDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public int CustomerId { get; set; }

        public string? BookingStatus { get; set; }

    }
}
