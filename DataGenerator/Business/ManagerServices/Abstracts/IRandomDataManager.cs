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
        bool AddRangeRandomData(List<RandomDataDTO> list);

        /// <summary>
        /// This function gets random data by given type and number of records. 
        /// </summary>
        /// <param name="numberOfRecords">The number of desired random data</param>
        /// <param name="typeId">The ObjectId of desired random data type</param>
        /// <returns>Result is all unique data list.</returns>
        List<RandomDataDTO> GetRandomlyById(int numberOfRecords, int typeId);

        /// <summary>
        /// This function gets random data by given types and number of records.
        /// </summary>
        /// <param name="numberOfRecords">The number of desired random data</param>
        /// <param name="typeIds">The ObjectId list of desired random data types.</param>
        /// <returns>Result is all unique data list.</returns>
        List<RandomDataDTO> GetRandomlyByIds(int numberOfRecords, List<int> typeIds);

        /// <summary>
        /// This function gets one random data by given type.
        /// </summary>
        /// <param name="typeId">The ObjectId of desired random data type.</param>
        /// <returns>Result is single random data.</returns>
        RandomDataDTO GetOneRandomById(int typeId);

    }
}
