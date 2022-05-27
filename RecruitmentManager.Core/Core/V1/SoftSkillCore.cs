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

        public async Task<List<SoftSkill>> GetSoftSkillsAsync()
        {
            return await _context.SoftSkill.ToListAsync();
        }

        public async Task<SoftSkill> CreateSoftSkillAsync(SoftSkillCreateDTO softSkill)
        {
            SoftSkill newSoftSkill = new()
            {
                Name = softSkill.Name,
            };

            var newSoftSkillCreated = _context.SoftSkill.Add(newSoftSkill);
            await _context.SaveChangesAsync();
            return newSoftSkillCreated.Entity;
        }

        public async Task<bool> UpdateSoftSkillAsync(SoftSkill entity)
        {
            SoftSkill softSkill = _context.SoftSkill.Find(entity.IdSoftSkill);
            softSkill.Name = entity.Name;
            _context.SoftSkill.Update(softSkill);
            int recordsAffected = await _context.SaveChangesAsync();
            return (recordsAffected == 1);
        }

        public async Task<bool> DeleteSoftSkillAsync(int softSkillId)
        {
            SoftSkill softSkill = _context.SoftSkill.Find(softSkillId);
            _context.SoftSkill.Remove(softSkill);
            int recordsAffeted = await _context.SaveChangesAsync();
            return (recordsAffeted == 1);
        }
    }
}
