using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class HardSkillCore
    {
        private readonly SqlServerContext _context;
        public HardSkillCore()
        {
            _context = new SqlServerContext();
        }

        public async Task<List<HardSkill>> GetVacanciesAsync()
        {
            return await _context.HardSkill.ToListAsync();
        }

        public async Task<HardSkill> CreateHardSkillAsync(HardSkillCreateDto entity)
        {
            HardSkill newHardSkill = new();

            newHardSkill.IdRecruiter = entity.IdRecruiter;
            newHardSkill.IdClient = entity.IdClient;
            newHardSkill.Seniority = entity.Seniority;
            newHardSkill.Skills = entity.Skills;
            newHardSkill.AvailableVacancies = entity.AvailableVacancies;
            newHardSkill.Description = entity.Description;
            newHardSkill.IsOpen = entity.IsOpen;
            newHardSkill.Candidates = entity.Candidates;
            newHardSkill.WinnerCandidates = entity.WinnerCandidates;

            var newHardSkillCreated = _context.HardSkill.Add(newHardSkill);

            await _context.SaveChangesAsync();

            return newHardSkillCreated.Entity;
        }

        public async Task<bool> UpdateHardSkillAsync(HardSkill hardSkillToUpdate)
        {
            HardSkill hardSkilll = _context.HardSkilll.Find(hardSkilllToUpdate.IdHardSkill);

            hardSkill.IdRecruiter = hardSkillToUpdate.IdRecruiter;
            hardSkill.IdClient = hardSkillToUpdate.IdClient;
            hardSkill.Seniority = hardSkillToUpdate.Seniority;
            hardSkill.Skills = hardSkillToUpdate.Skills;
            hardSkill.AvailableVacancies = hardSkillToUpdate.AvailableVacancies;
            hardSkill.Description = hardSkillToUpdate.Description;
            hardSkill.IsOpen = hardSkillToUpdate.IsOpen;
            hardSkill.Candidates = hardSkillToUpdate.Candidates;
            hardSkill.WinnerCandidates = hardSkillToUpdate.WinnerCandidates;

            _context.HardSkill.Update(hardSkill);

            int recordsAffected = await _context.SaveChangesAsync();

            return (recordsAffected == 1);
        }

        public async Task<bool> DeleteHardSkillAsync(int idHardSkill)
        {
            HardSkill hardSkill = _context.HardSkill.Find(idHardSkill);

            _context.Remove(hardSkill);

            return await _context.SaveChangesAsync() != 0;
        }
    }
}
