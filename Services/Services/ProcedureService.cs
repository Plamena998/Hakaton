using DBContext;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly HakDbContext _dbContext;

        public ProcedureService(HakDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Procedure>> GetAllAsync()
        {
            return await _dbContext.procedures.AsNoTracking().ToListAsync();
        }

        public async Task<Procedure?> GetByIdAsync(int id)
        {
            return await _dbContext.procedures.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Procedure> CreateAsync(Procedure procedure)
        {
            await _dbContext.procedures.AddAsync(procedure);
            await _dbContext.SaveChangesAsync();
            return procedure;
        }

        public async Task<bool> UpdateAsync(Procedure procedure)
        {
            var exists = await _dbContext.procedures.AnyAsync(p => p.Id == procedure.Id);
            if (!exists)
            {
                return false;
            }
            _dbContext.procedures.Update(procedure);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.procedures.FirstOrDefaultAsync(p => p.Id == id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.procedures.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}


