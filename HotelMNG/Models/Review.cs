using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public string? EntityType { get; set; }

    public int? EntityId { get; set; }

    public int? UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public byte[] CreatedAt { get; set; } = null!;
}
