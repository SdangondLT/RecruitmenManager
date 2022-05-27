using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecruitmentManager.Core.Utils;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<ResponseService<List<Candidate>>> GetCandidateAsync()
        {
            try
            {
                var response = await _context.Candidate.ToListAsync();
                return new ResponseService<List<Candidate>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", System.Net.HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return new ResponseService<List<Candidate>>(true, $"Error: {ex.Message}", System.Net.HttpStatusCode.InternalServerError, new List<Candidate>());
            }
        }

        //public async Task<Candidate> CreateCandidateAsync(CandidateCreateDto entity)
        //{
        //    Candidate newCandidate = new();

        //    newCandidate.Name = entity.Name;
        //    newCandidate.CV = entity.CV;
        //    newCandidate.CandidateType = entity.CandidateType;
        //    //newCandidate.HardSkills = entity.HardSkills;    
        //    //newCandidate.SoftSkills = entity.SoftSkills;
        //    newCandidate.Seniority = entity.Seniority;
        //    newCandidate.YearsOfExperience = entity.YearsOfExperience;


        //    var newCandidateCreated = _context.Candidate.Add(newCandidate);

        //    await _context.SaveChangesAsync();

        //    return newCandidateCreated.Entity;
        //}
        public async Task<ResponseService<Candidate>> CreateCandidateAsync(CandidateCreateDto entity)
        {
            Candidate newCandidate = new();

            newCandidate.Name = entity.Name;
            newCandidate.CV = entity.CV;
            newCandidate.CandidateType = entity.CandidateType;
            //newCandidate.HardSkills = entity.HardSkills;    
            //newCandidate.SoftSkills = entity.SoftSkills;
            newCandidate.Seniority = entity.Seniority;
            newCandidate.YearsOfExperience = entity.YearsOfExperience;

            try
            {
                var newCandidateCreated = _context.Candidate.Add(newCandidate);
                await _context.SaveChangesAsync();

                return new ResponseService<Candidate>(false, "Succefully created Client", HttpStatusCode.Created, newCandidateCreated.Entity); ;
            }
            catch (Exception ex)
            {
                return new ResponseService<Candidate>(true, $"Record not created {ex.Message}", HttpStatusCode.InternalServerError, new Candidate());
            }
        }
        public async Task<bool> UpdateCandidateAsync(Candidate candidateToUpdated)
        {
            Candidate candidate = _context.Candidate.Find(candidateToUpdated.IdCandidate);
            candidate.Name = candidateToUpdated.Name;
            candidate.CV = candidateToUpdated.CV;   
            candidate.CandidateType = candidateToUpdated.CandidateType;
            //candidate.HardSkills = candidateToUpdated.HardSkills;   
            //candidate.SoftSkills = candidateToUpdated.SoftSkills;
            candidate.Seniority=candidateToUpdated.Seniority;
            candidate.YearsOfExperience= candidateToUpdated.YearsOfExperience;
            

            _context.Candidate.Update(candidate);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }

        public async Task<bool> DeleteCandidateAsync(int idCandidateToDelete)
        {
            Candidate candidate = _context.Candidate.Find(idCandidateToDelete);


            _context.Candidate.Remove(candidate);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
