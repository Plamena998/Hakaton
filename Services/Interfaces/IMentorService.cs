using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMentorService
    {
        Task<List<Mentor>> GetAllAsync();
        Task<Mentor?> GetByIdAsync(int id);
        Task<Mentor> CreateAsync(Mentor mentor);
        Task<bool> UpdateAsync(Mentor mentor);
        Task<bool> DeleteAsync(int id);

        Task<List<Mentor>> GetAllFreeByScienceIdAsync(int scienceId);
    }
}


