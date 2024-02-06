﻿namespace CODEPULSE.Models.DTO
{
    public class UpdateBlogPostRequestDTO
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string FeaturedImageurl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Isvisible { get; set; }
        public List<Guid> Categories { get; set; } = new List<Guid>();
    }
}
