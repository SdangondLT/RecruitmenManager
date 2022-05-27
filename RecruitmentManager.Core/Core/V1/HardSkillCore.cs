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
            //_context = new SqlServerContext();
        }

        public async Task<List<HardSkill>> GetHardSkillsAsync()
        {
            return await _context.HardSkill.ToListAsync();
        }

        public async Task<HardSkill> CreateHardSkillAsync(HardSkillCreateDTO hardSkill)
        {
            HardSkill newHardSkill = new()
            {
                Name = hardSkill.Name,
            };

            var newHardSkillCreated = _context.HardSkill.Add(newHardSkill);
            await _context.SaveChangesAsync();
            return newHardSkillCreated.Entity;
        }

        public async Task<bool> UpdateHardSkillAsync(HardSkill entity)
        {
            HardSkill hardSkill = _context.HardSkill.Find(entity.IdHardSkill);
            hardSkill.Name = entity.Name;
            _context.HardSkill.Update(hardSkill);
            int recordsAffected = await _context.SaveChangesAsync();
            return (recordsAffected == 1);
        }

        public async Task<bool> DeleteHardSkillAsync(int hardSkillId)
        {
            HardSkill hardSkill = _context.HardSkill.Find(hardSkillId);
            _context.HardSkill.Remove(hardSkill);
            int recordsAffeted = await _context.SaveChangesAsync();
            return (recordsAffeted == 1);
        }
    }
}
