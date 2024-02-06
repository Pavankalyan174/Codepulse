using CODEPULSE.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CODEPULSE.Data
{
    public class Applicationdbcontext : DbContext
    {
        public Applicationdbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blogpost> Blogposts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
    }
}
