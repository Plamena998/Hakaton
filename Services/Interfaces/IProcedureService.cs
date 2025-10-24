using Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProcedureService
    {
        Task<List<Procedure>> GetAllAsync();
        Task<Procedure?> GetByIdAsync(int id);
        Task<Procedure> CreateAsync(Procedure procedure);
        Task<bool> UpdateAsync(Procedure procedure);
        Task<bool> DeleteAsync(int id);
    }
}


