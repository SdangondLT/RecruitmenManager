using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class VacancyCore
    {
        private readonly SqlServerContext _context;
        public VacancyCore()
        {
            //_context = new SqlServerContext();
        }

        public async Task<List<Vacancy>> GetVacanciesAsync()
        {
            return await _context.Vacancy.ToListAsync();
        }

        public async Task<Vacancy> CreateVacancyAsync(VacancyCreateDto entity)
        {
            Vacancy newVacancy = new();

            newVacancy.IdRecruiter = entity.IdRecruiter;
            newVacancy.IdClient = entity.IdClient;
            newVacancy.Seniority = entity.Seniority;
            newVacancy.Skills = entity.Skills;
            newVacancy.AvailableVacancies = entity.AvailableVacancies;
            newVacancy.Description = entity.Description;
            newVacancy.IsOpen = entity.IsOpen;
            newVacancy.Candidates = entity.Candidates;
            newVacancy.WinnerCandidates = entity.WinnerCandidates;

            var newVacancyCreated = _context.Vacancy.Add(newVacancy);

            await _context.SaveChangesAsync();

            return newVacancyCreated.Entity;
        }

        public async Task<bool> UpdateVacancyAsync(Vacancy vacancyToUpdate)
        {
            Vacancy vacancy = _context.Vacancy.Find(vacancyToUpdate.IdVacancy);

            vacancy.IdRecruiter = vacancyToUpdate.IdRecruiter;
            vacancy.IdClient = vacancyToUpdate.IdClient;
            vacancy.Seniority = vacancyToUpdate.Seniority;
            vacancy.Skills = vacancyToUpdate.Skills;
            vacancy.AvailableVacancies = vacancyToUpdate.AvailableVacancies;
            vacancy.Description = vacancyToUpdate.Description;
            vacancy.IsOpen = vacancyToUpdate.IsOpen;
            vacancy.Candidates = vacancyToUpdate.Candidates;
            vacancy.WinnerCandidates = vacancyToUpdate.WinnerCandidates;

            _context.Vacancy.Update(vacancy);

            int recordsAffected = await _context.SaveChangesAsync();

            return (recordsAffected == 1);
        }

        public async Task<bool> DeleteVacancyAsync(int idVacancy)
        {
            Vacancy vacancy = _context.Vacancy.Find(idVacancy);

            _context.Remove(vacancy);

            return await _context.SaveChangesAsync() != 0;
        }
    }
}
