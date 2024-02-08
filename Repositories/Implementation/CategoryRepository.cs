using CODEPULSE.Data;
using CODEPULSE.Models.Domain;
using CODEPULSE.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CODEPULSE.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Applicationdbcontext dbcontext;


        public CategoryRepository(Applicationdbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Category> createAsync(Category category)
        {
            await dbcontext.Categories.AddAsync(category);
            await dbcontext.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await dbcontext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory is null)
            {
                return null;
            }

            dbcontext.Categories.Remove(existingCategory);
            await dbcontext.SaveChangesAsync();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return existingCategory;
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbcontext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await dbcontext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await dbcontext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (existingCategory != null)
            {
                dbcontext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbcontext.SaveChangesAsync();
                return category;
            }

            return null;
        }

    }
}
