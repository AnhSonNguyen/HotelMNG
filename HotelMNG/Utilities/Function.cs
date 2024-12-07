namespace HotelMNG.Utilities
{
    public static class Function
    {
        public static string FormatPrice(decimal price)
        {
            return $"{price:C}";
        }
    }
}
