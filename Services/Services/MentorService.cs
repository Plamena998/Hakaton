using DBContext;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MentorService : IMentorService
    {
        private readonly HakDbContext _dbContext;

        public MentorService(HakDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Mentor>> GetAllAsync()
        {
            return await _dbContext.mentors.AsNoTracking().ToListAsync();
        }

        public async Task<Mentor?> GetByIdAsync(int id)
        {
            return await _dbContext.mentors.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Mentor> CreateAsync(Mentor mentor)
        {
            await _dbContext.mentors.AddAsync(mentor);
            await _dbContext.SaveChangesAsync();
            return mentor;
        }

        public async Task<bool> UpdateAsync(Mentor mentor)
        {
            var exists = await _dbContext.mentors.AnyAsync(m => m.Id == mentor.Id);
            if (!exists)
            {
                return false;
            }

            _dbContext.mentors.Update(mentor);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.mentors.FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.mentors.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}


