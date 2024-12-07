namespace HotelMNG.Models
{
    public partial class BlogPost
    {
        public int BlogPostId { get; set; }
        public string? Title { get; set; }
        public string? Alias { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryID { get; set; }
        public string? Category { get; set; }
        public string? Content { get; set; }
    }
}
