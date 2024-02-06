using CODEPULSE.Models.Domain;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace CODEPULSE.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<BlogImage> Upload (IFormFile file, BlogImage blogImage);

        Task<IEnumerable<BlogImage>> GetAll();
        
    }
}
