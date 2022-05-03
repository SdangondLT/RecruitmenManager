using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class ClientCore
    {
        private readonly SqlServerContext _context;
        public ClientCore()
        {
            _context = new SqlServerContext();
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            return await _context.Client.ToListAsync();
        }


    }
}
