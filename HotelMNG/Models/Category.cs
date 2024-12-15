using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
}
