using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class InterviewerCore
    {
        private readonly SqlServerContext _context;

        public InterviewerCore()
        {
            //_context = new SqlServerContext();
        }

        public async Task<List<Interviewer>> GetInterviewersAsync()
        {
            return await _context.Interviewer.ToListAsync();
        }

        public async Task<Interviewer> CreateInterviewerAsync(InterviewerCreateDTO interviewer)
        {
            Interviewer newInterviewer = new()
            {
                Name = interviewer.Name,
                Seniority = interviewer.Seniority,
            };

            var newInterviewerCreated = _context.Interviewer.Add(newInterviewer);
            await _context.SaveChangesAsync();
            return newInterviewerCreated.Entity;
        }

        public async Task<bool> UpdateInterviewerAsync(Interviewer entity)
        {
            Interviewer interviewer = _context.Interviewer.Find(entity.IdInterviewer);
            interviewer.Name = entity.Name;
            interviewer.Seniority = entity.Seniority;
            _context.Interviewer.Update(interviewer);
            int recordsAffected = await _context.SaveChangesAsync();
            return (recordsAffected == 1);
        }

        public async Task<bool> DeleteInterviewerAsync(int interviewerId)
        {
            Interviewer interviewer = _context.Interviewer.Find(interviewerId);
            _context.Interviewer.Remove(interviewer);
            int recordsAffeted = await _context.SaveChangesAsync();
            return (recordsAffeted == 1);
        }
    }
}
