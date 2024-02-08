using CODEPULSE.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CODEPULSE.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> createAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category?> GetById(Guid id);

        Task<Category?> UpdateAsync(Category category);

        Task<Category?> DeleteAsync(Guid id);

    }
}
