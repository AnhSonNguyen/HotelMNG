using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? RoomId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? CheckInDate { get; set; }

    public DateOnly? CheckOutDate { get; set; }

    public string? Status { get; set; }

    public virtual User? User { get; set; }
}
