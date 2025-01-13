using System;
using System.Collections.Generic;

namespace HotelMNG.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }

        public int? ActualRoomId { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public string RoomType { get; set; }

        public virtual ActualRoom ActualRoom { get; set; }
    }
}
