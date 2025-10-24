using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IScienceService
    {
        Task<List<Science>> GetAllAsync();
        Task<Science?> GetByIdAsync(int id);
        Task<Science> CreateAsync(Science science);
        Task<bool> UpdateAsync(Science science);
        Task<bool> DeleteAsync(int id);
    }
}


