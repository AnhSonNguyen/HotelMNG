using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class Gallery
{
    public int GalleryId { get; set; }

    public string? EntityType { get; set; }

    public int? EntityId { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }
}
