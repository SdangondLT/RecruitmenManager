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

        public async Task<List<Recruiter>> GetRecruiters()
        {
            return await _context.Recruiter.ToListAsync();
        }

        public async Task<Recruiter> CreateRecruiter(RecruiterCreateDto recruiter)
        {
            Recruiter newRecruiter = new Recruiter();

            newRecruiter.Name = recruiter.Name;

            var newRecruiterCreated = _context.Recruiter.Add(newRecruiter);

            await _context.SaveChangesAsync();

            return newRecruiterCreated.Entity;
        }

        public async Task<bool> UpdateRecruiter(Recruiter recruiterToUpdate)
        {
            Recruiter recruiter = _context.Recruiter.Find(recruiterToUpdate.IdRecruiter);

            recruiter.Name = recruiterToUpdate.Name;

            _context.Recruiter.Update(recruiter);

            int recruitersUpdated =  await _context.SaveChangesAsync();

            return (recruitersUpdated == 1);
        }

        public async Task<List<Recruiter>> DeleteRecruiter(int id)
        {
            Recruiter recruiterToDelete = _context.Recruiter.Find(id);

            _context.Recruiter.Remove(recruiterToDelete);

            await _context.SaveChangesAsync();

            return await _context.Recruiter.ToListAsync();
        }
    }
}
