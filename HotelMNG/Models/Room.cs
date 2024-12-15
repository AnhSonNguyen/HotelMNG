using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Size { get; set; }

    public int? Capacity { get; set; }

    public string? Bed { get; set; }

    public string? Image { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
}
