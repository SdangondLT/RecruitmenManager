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
    public class CandidateCore
    {
        private readonly SqlServerContext _context;

        public CandidateCore()
        {
            _context = new SqlServerContext();
        }
        public async Task<List<Candidate>> GetClientsAsync()
        {
            return await _context.Candidate.ToListAsync();
        }

        public async Task<Candidate> CreateCandidateAsync(CandidateCreateDto entity)
        {
            Candidate newCandidate = new();

            newCandidate.Name = entity.Name;
            newCandidate.CV = entity.CV;
            newCandidate.CandidateType = entity.CandidateType;
            newCandidate.HardSkills = entity.HardSkills;    
            newCandidate.SoftSkills = entity.SoftSkills;
            newCandidate.Seniority = entity.Seniority;
            newCandidate.YearsOfExperience = entity.YearsOfExperience;
            

            var newCandidateCreated = _context.Candidate.Add(newCandidate);

            await _context.SaveChangesAsync();

            return newCandidateCreated.Entity;
        }
    }
}
