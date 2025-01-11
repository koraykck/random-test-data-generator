using Business.ManagerServices.DTOs;
using Domain.Models;
using Domain.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ManagerServices.Abstracts
{
    public interface IRandomDataManager : IManager<RandomData>
    {
        Task<bool> AddRangeRandomData(List<RandomDataDTO> list);

    }
}
