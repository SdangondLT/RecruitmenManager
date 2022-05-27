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
    public class AssessmentCore
    {

        private readonly SqlServerContext _context;
        public AssessmentCore()
        {
            //_context = new SqlServerContext();
        }

        public async Task<List<Assessment>> GetAssessmentsAsync()
        {
            return await _context.Assessment.ToListAsync();
        }

        public async Task<Assessment> CreateAssessmentAsync(AssessmentCreateDto entity)
        {
            Assessment newAssessment = new();

            newAssessment.IdCandidate = entity.IdCandidate;
            newAssessment.IdQuestionnaire = entity.IdQuestionnaire;
            newAssessment.NameAssessment = entity.NameAssessment;

            var newAssessmentCreated = _context.Assessment.Add(newAssessment);

            await _context.SaveChangesAsync();

            return newAssessmentCreated.Entity;
        }

        public async Task<bool> UpdateAssessmentAsync(Assessment assessmentToUpdated)
        {
            Assessment assessment = _context.Assessment.Find(assessmentToUpdated.IdAssessment);
            assessment.NameAssessment = assessmentToUpdated.NameAssessment;

            _context.Assessment.Update(assessment);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteAssessmentAsync(Assessment assessmentToUpdated)
        {
            Assessment assessment = _context.Assessment.Find(assessmentToUpdated.IdAssessment);

            _context.Assessment.Remove(assessment);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
