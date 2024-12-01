using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class Amenity
{
    public int AmenityId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
}
