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
    public class InterviewCore
    {
        private readonly SqlServerContext _context;
        public InterviewCore()
        {
            _context = new SqlServerContext();
        }

        public async Task<Interview> GetInterviewAsync(int id)
        {
            return await _context.Interview.FindAsync(id);
        }

        public async Task<List<Interview>> GetInterviewsAsync()
        {
            return await _context.Interview.ToListAsync();
        }

        public async Task<Interview> CreateInterviewAsync(InterviewCreateDto entity)
        {
            Interview newInterview = new();

            newInterview.Name = entity.Name;
            newInterview.MeetingLink = entity.MeetingLink;
            newInterview.Date = entity.Date;
            newInterview.IdInterviwer = entity.IdInterviwer;
            newInterview.IdRecruiter = entity.IdRecruiter;
            newInterview.IdCandidate = entity.IdCandidate;
            newInterview.Evaluation = entity.Evaluation;
            newInterview.IsActive = entity.IsActive;

            var newInterviewCreated = _context.Interview.Add(newInterview);

            await _context.SaveChangesAsync();

            return newInterviewCreated.Entity;
        }

        public async Task<bool> UpdateInterviewAsync(Interview interviewToUpdated)
        {
            Interview interview = _context.Interview.Find(interviewToUpdated.IdInterview);
            interview.Name = interviewToUpdated.Name;
            interview.MeetingLink = interviewToUpdated.MeetingLink;
            interview.Date = interviewToUpdated.Date;
            interview.IdInterviwer = interviewToUpdated.IdInterviwer;
            interview.IdRecruiter = interviewToUpdated.IdRecruiter;
            interview.Evaluation = interviewToUpdated.Evaluation;
            interview.IsActive = interviewToUpdated.IsActive;

            _context.Interview.Update(interview);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteInterviewAsync(int idInterview)
        {
            Interview interview = _context.Interview.Find(idInterview);

            _context.Interview.Remove(interview);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
