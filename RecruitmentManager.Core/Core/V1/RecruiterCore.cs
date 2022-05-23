using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class RecruiterCore
    {
        private readonly SqlServerContext _context;
        public RecruiterCore()
        {
            _context = new SqlServerContext();
        }

        public async Task<List<Recruiter>> GetRecruitersAsync()
        {
            return await _context.Recruiter.ToListAsync();
        }

        public async Task<Recruiter> GetRecruiterAsync(int recruiterId)
        {
            return await _context.Recruiter.FindAsync(recruiterId);
        }

        public async Task<Recruiter> CreateRecruitersAsync(RecruiterCreateDto entity)
        {
            Recruiter newRecruiter = new();

            newRecruiter.Name = entity.Name;
            newRecruiter.PhoneNumber = entity.PhoneNumber;

            var newRecruiterCreated = _context.Recruiter.Add(newRecruiter);

            await _context.SaveChangesAsync();

            return newRecruiterCreated.Entity;
        }

        public async Task<bool> UpdateRecruitersAsync(Recruiter recruiterToUpdated)
        {
            Recruiter recruiter = _context.Recruiter.Find(recruiterToUpdated.IdRecruiter);
            recruiter.Name = recruiterToUpdated.Name;
            recruiter.PhoneNumber = recruiterToUpdated.PhoneNumber;

            _context.Recruiter.Update(recruiter);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteRecruitersAsync(Recruiter recruiterToDelete)
        {
            Recruiter recruiter = _context.Recruiter.Find(recruiterToDelete.IdRecruiter);

            _context.Recruiter.Remove(recruiter);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
