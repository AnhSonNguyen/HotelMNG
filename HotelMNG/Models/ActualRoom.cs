using System;
using System.Collections.Generic;

namespace HotelMNG.Models
{
    public partial class ActualRoom
    {
        public int ActualRoomId { get; set; }

        public string RoomNumber { get; set; }

        public string? RoomType { get; set; } // Sử dụng thuộc tính nullable

        public string? Status { get; set; } // Sử dụng thuộc tính nullable

        public string? Notes { get; set; } // Sử dụng thuộc tính nullable

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
