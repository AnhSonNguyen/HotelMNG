﻿using System;
using System.Collections.Generic;

namespace HotelMNG.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Message { get; set; }

    public byte[] CreatedAt { get; set; } = null!;
}
