using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class SoftSkillCore
    {
        private readonly SqlServerContext _context;
        public SoftSkillCore()
        {
            _context = new SqlServerContext();
        }

        public async Task<List<SoftSkill>> GetVacanciesAsync()
        {
            return await _context.SoftSkill.ToListAsync();
        }

        public async Task<SoftSkill> CreateSoftSkillAsync(SoftSkillCreateDto entity)
        {
            SoftSkill newSoftSkill = new();

            newSoftSkill.IdRecruiter = entity.IdRecruiter;
            newSoftSkill.IdClient = entity.IdClient;
            newSoftSkill.Seniority = entity.Seniority;
            newSoftSkill.Skills = entity.Skills;
            newSoftSkill.AvailableVacancies = entity.AvailableVacancies;
            newSoftSkill.Description = entity.Description;
            newSoftSkill.IsOpen = entity.IsOpen;
            newSoftSkill.Candidates = entity.Candidates;
            newSoftSkill.WinnerCandidates = entity.WinnerCandidates;

            var newSoftSkillCreated = _context.SoftSkill.Add(newSoftSkill);

            await _context.SaveChangesAsync();

            return newSoftSkillCreated.Entity;
        }

        public async Task<bool> UpdateSoftSkillAsync(SoftSkill softSkillToUpdate)
        {
            SoftSkill softSkilll = _context.SoftSkilll.Find(softSkilllToUpdate.IdSoftSkill);

            softSkill.IdRecruiter = softSkillToUpdate.IdRecruiter;
            softSkill.IdClient = softSkillToUpdate.IdClient;
            softSkill.Seniority = softSkillToUpdate.Seniority;
            softSkill.Skills = softSkillToUpdate.Skills;
            softSkill.AvailableVacancies = softSkillToUpdate.AvailableVacancies;
            softSkill.Description = softSkillToUpdate.Description;
            softSkill.IsOpen = softSkillToUpdate.IsOpen;
            softSkill.Candidates = softSkillToUpdate.Candidates;
            softSkill.WinnerCandidates = softSkillToUpdate.WinnerCandidates;

            _context.SoftSkill.Update(softSkill);

            int recordsAffected = await _context.SaveChangesAsync();

            return (recordsAffected == 1);
        }

        public async Task<bool> DeleteSoftSkillAsync(int idSoftSkill)
        {
            SoftSkill softSkill = _context.SoftSkill.Find(idSoftSkill);

            _context.Remove(softSkill);

            return await _context.SaveChangesAsync() != 0;
        }
    }
}
