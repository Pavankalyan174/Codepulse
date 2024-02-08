using CODEPULSE.Data;
using CODEPULSE.Models.Domain;
using CODEPULSE.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CODEPULSE.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly Applicationdbcontext dbcontext;

        public BlogPostRepository(Applicationdbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Blogpost> CreateAsync(Blogpost blogpost)
        {
            await dbcontext.Blogposts.AddAsync(blogpost);
            await dbcontext.SaveChangesAsync();
            return blogpost;
        }

        public async Task<Blogpost?> DeleteAsync(Guid id)
        {
           var existingBlogpost = await dbcontext.Blogposts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBlogpost != null)
            {
                dbcontext.Blogposts.Remove(existingBlogpost);
                await dbcontext.SaveChangesAsync();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                return existingBlogpost;
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
            }

            return null;
        }

       

        public async Task<IEnumerable<Blogpost>> GetAllAsync()
        {
            return await dbcontext.Blogposts.Include(x => x.Categories).ToListAsync();
        }

        public async Task<Blogpost?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Blogposts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);
        }

       
        public async Task<Blogpost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await dbcontext.Blogposts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<Blogpost?> UpdateAsync(Blogpost blogpost)
        {
            var existingBlogpost = await dbcontext.Blogposts.Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == blogpost.Id);

            if (existingBlogpost == null)
            {
                return null;
            }

            // Update BlogPost
            dbcontext.Entry(existingBlogpost).CurrentValues.SetValues(blogpost);

            // Update Categories
            existingBlogpost.Categories = blogpost.Categories;

            await dbcontext.SaveChangesAsync();

            return blogpost;
        }

      
    }
}
