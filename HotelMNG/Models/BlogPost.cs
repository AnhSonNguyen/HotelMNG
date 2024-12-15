using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class BlogPost
{
    public int BlogPostId { get; set; }

    public string Title { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CategoryId { get; set; }

    public string? Category { get; set; }

    public string? Content { get; set; }

    public virtual Category? CategoryNavigation { get; set; }
}
