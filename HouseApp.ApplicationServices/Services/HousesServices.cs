using HouseApp.Data;
using HouseApp.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HouseApp.Core.Domain;

namespace HouseApp.ApplicationServices.Services
{
    public class HousesServices : IHousesServices
    {
        private readonly HouseAppContext _context;

        public HousesServices (HouseAppContext context)
        {
            _context = context;
        }
        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
