using CODEPULSE.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CODEPULSE.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task<Blogpost> CreateAsync(Blogpost blogpost);
        Task<IEnumerable<Blogpost>> GetAllAsync();
        Task<Blogpost?> GetByIdAsync (Guid id);
        Task<Blogpost?> GetByUrlHandleAsync(string urlHandle);
        Task<Blogpost?> UpdateAsync (Blogpost blogpost);
        Task<Blogpost?> DeleteAsync (Guid id);
    
    }
}
