using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using codegeneratorservice.Model;
using codegeneratorservice.IntegrationService;
using AutoMapper;

namespace codegeneratorservice.Service
{
    public class UniqueCodeGenerator : IUniqueCodeGenerator
    {
        private readonly IIntegrationservice _IntegrationService;
        private readonly IMapper _mapper;
        public UniqueCodeGenerator(IIntegrationservice iService, IMapper mapper)
        {
            _IntegrationService = iService;
            _mapper = mapper;
        }

        /// <summary>
        /// Service to generate the unique code and 
        /// calls the end point to stores in the data base. 
        /// </summary>
        /// <param name="intCount"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> GenerateUniqueCode(int intCount)
        {
            if (intCount <= 0)
                return new ResponseMessage { Message = "Count should be greater than Zero", statusCode = 400 };

            //Get the data from the db 
            ResponseMessage objResponseData = await _IntegrationService.GetData();
            List<UniqueCodeDTO> dbUniqueCodeList = _mapper.Map<List<UniqueCodeDTO>>(objResponseData.Data);

            var stopwatch = Stopwatch.StartNew();
            //generate unique code.
            List<UniqueCodeDTO> uniqueCodes = GenerateUniqueCodes(intCount, dbUniqueCodeList);
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            // Call the storage microservice API to store the unique codes
            var res = _IntegrationService.AddCodeToStorage(uniqueCodes);
            return new ResponseMessage
            {
                Message = $"codes generated in (hh:mm:ss:ms)-  : {elapsedTime.Hours} : {elapsedTime.Minutes} :{elapsedTime.Seconds} : {elapsedTime.Milliseconds}",
                statusCode = 200
            };
        }

        /// <summary>
        /// Compares generated unique code
        /// Checks for duplication. 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="dbCodeList"></param>
        /// <returns>List of unique codes </returns>
        private List<UniqueCodeDTO> GenerateUniqueCodes(int count, List<UniqueCodeDTO> dbCodeList)
        {
            HashSet<UniqueCodeDTO> dbuniqueCodeList = new HashSet<UniqueCodeDTO>(dbCodeList);

            // Generate unique codes based on the specified count and length
            HashSet<UniqueCodeDTO> uniqueCodes = new HashSet<UniqueCodeDTO>();

            while (uniqueCodes.Count < count)
            {
                string code = GenerateRandomCode();
                UniqueCodeDTO objUniqueCode = new UniqueCodeDTO { strUniqueCode = code };
                if (!uniqueCodes.Contains(objUniqueCode) && !dbuniqueCodeList.Contains(objUniqueCode))
                    uniqueCodes.Add(objUniqueCode);
            }
            return uniqueCodes.ToList<UniqueCodeDTO>();
        }

        /// <summary>
        /// Function to generate the unique code. 
        /// </summary>
        /// <returns>generated unique code </returns>
        private string GenerateRandomCode()
        {
            // Generate a random code of maximum length 5
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var code = new string(Enumerable.Repeat(characters, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return code;
        }


    }
}