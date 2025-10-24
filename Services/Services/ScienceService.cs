using DBContext;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ScienceService : IScienceService
    {
        private readonly HakDbContext _dbContext;

        public ScienceService(HakDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Science>> GetAllAsync()
        {
            return await _dbContext.sciences.AsNoTracking().ToListAsync();
        }

        public async Task<Science?> GetByIdAsync(int id)
        {
            return await _dbContext.sciences.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Science> CreateAsync(Science science)
        {
            await _dbContext.sciences.AddAsync(science);
            await _dbContext.SaveChangesAsync();
            return science;
        }

        public async Task<bool> UpdateAsync(Science science)
        {
            var exists = await _dbContext.sciences.AnyAsync(s => s.Id == science.Id);
            if (!exists)
            {
                return false;
            }
            _dbContext.sciences.Update(science);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.sciences.FirstOrDefaultAsync(s => s.Id == id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.sciences.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}


