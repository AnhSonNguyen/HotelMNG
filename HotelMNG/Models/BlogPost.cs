using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class BlogPost
{
    public int BlogPostId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public byte[] CreatedAt { get; set; } = null!;
}
