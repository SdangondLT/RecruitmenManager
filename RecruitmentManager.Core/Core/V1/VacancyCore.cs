using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecruitmentManager.Core.Core.ErrorsHandler;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using RecruitmentManager.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class VacancyCore
    {
        private readonly SqlServerContext _context;
        private readonly ILogger<Vacancy> _logger;
        private readonly ErrorHandler<Vacancy> _errorHandler;
        private readonly IMapper _mapper;
        public VacancyCore(ILogger<Vacancy> logger, IMapper mapper, SqlServerContext context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Vacancy>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Vacancy>>> GetVacanciesAsync()
        {
            try
            {
                var response = await _context.Vacancy.ToListAsync();
                return new ResponseService<List<Vacancy>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetVacanciesAsync", new List<Vacancy>());
            }
        }

        public async Task<ResponseService<Vacancy>> CreateVacancyAsync(VacancyCreateDto entity)
        {
            Vacancy newVacancy = new();
            newVacancy = _mapper.Map<Vacancy>(entity);

            try
            {
                var newVacancyCreated = _context.Vacancy.Add(newVacancy);
                await _context.SaveChangesAsync();

                return new ResponseService<Vacancy>(false, "Succefully Created Vacancy", HttpStatusCode.Created, newVacancyCreated.Entity);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "CreateVacancyAsync", new Vacancy());
            }
        }

        public async Task<ResponseService<bool>> UpdateVacancyAsync(Vacancy vacancyToUpdate)
        {
            Vacancy vacancy = _mapper.Map<Vacancy>(vacancyToUpdate);

            try
            {
                _context.Vacancy.Update(vacancy);
                int recordsAffected = await _context.SaveChangesAsync();
                return new ResponseService<bool>(false, "Succefully Updated Vacancy", HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "UpdateVacancyAsync", false);
            }
        }

        public async Task<ResponseService<bool>> DeleteVacancyAsync(int idVacancy)
        {
            Vacancy vacancy = _context.Vacancy.Find(idVacancy);

            try
            {
                _context.Remove(vacancy);
                await _context.SaveChangesAsync();
                return new ResponseService<bool>(false, "Succefully Deleted Vacancy", HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "DeleteVacancyAsync", false);
            }
        }
    }
}
