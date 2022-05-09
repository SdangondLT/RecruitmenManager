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

        public async Task<bool> UpdateCandidateAsync(Candidate candidateToUpdated)
        {
            Candidate candidate = _context.Candidate.Find(candidateToUpdated.IdCandidate);
            candidate.Name = candidateToUpdated.Name;
            candidate.CV = candidateToUpdated.CV;   
            candidate.CandidateType = candidateToUpdated.CandidateType;
            candidate.HardSkills = candidateToUpdated.HardSkills;   
            candidate.SoftSkills = candidateToUpdated.SoftSkills;
            candidate.Seniority=candidateToUpdated.Seniority;
            candidate.YearsOfExperience= candidateToUpdated.YearsOfExperience;
            

            _context.Candidate.Update(candidate);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteCandidateAsync(Candidate candidateToDelete)
        {
            Candidate candidate = _context.Candidate.Find(candidateToDelete.IdCandidate);
            
            candidate.Name = candidateToDelete.Name;
            candidate.CV = candidateToDelete.CV;
            candidate.CandidateType = candidateToDelete.CandidateType;
            candidate.HardSkills = candidateToDelete.HardSkills;
            candidate.SoftSkills = candidateToDelete.SoftSkills;
            candidate.Seniority = candidateToDelete.Seniority;
            candidate.YearsOfExperience = candidateToDelete.YearsOfExperience;


            _context.Candidate.Remove(candidate);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
