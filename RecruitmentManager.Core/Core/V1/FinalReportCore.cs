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
    public class FinalReportCore
    {
        private readonly SqlServerContext _context;

        public FinalReportCore()
        {
            //_context = new SqlServerContext();
        }

        public async Task<List<FinalReport>> GetFinalReportsAsync()
        {
            return await _context.FinalReport.ToListAsync();
        }

        public async Task<FinalReport> GetFinalReportAsync(int id)
        {
            return await _context.FinalReport.FindAsync(id);
        }

        public async Task<FinalReport> CreateFinalReportAsync(FinalReportCreateDto entity)
        {
            FinalReport newReport = new();

            newReport.IdCandidate = entity.IdCandidate;
            newReport.Seniority = entity.Seniority;
            newReport.EnglishLevel = entity.EnglishLevel;
            newReport.Comments = entity.Comments;

            var newReportCreated = _context.FinalReport.Add(newReport);

            await _context.SaveChangesAsync();

            return newReportCreated.Entity;
        }

        public async Task<bool> UpdateFinalReportAsync(int id,FinalReportUpdateDto reportToUpdate)
        {
            FinalReport report = _context.FinalReport.Find(id);
            
            report.Seniority=reportToUpdate.Seniority;
            report.EnglishLevel = reportToUpdate.EnglishLevel;
            report.Comments = reportToUpdate.Comments;
            
            _context.FinalReport.Update(report);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteFinalReportAsync(int id)
        {
            _context.FinalReport.Remove(_context.FinalReport.Find(id));
            
            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

    }
}
