using HouseApp.Core.Domain;
using HouseApp.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApp.Core.ServiceInterface
{
    public interface IHousesServices
    {
        Task<House> GetAsync(Guid id);
        Task<House> Create(HouseDto dto);
    }
}
