using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using storageservice.Models;
using storageservice.UniqueCodeContext;


namespace storageservice.Service
{
    public class StorageService : IStorageService
    {
        private readonly UniquecodeContext _context;
        public StorageService(UniquecodeContext context)
        {
            _context = context;
        }
        public async Task<ResponseMessage> AddData(List<UniqueCode> lstUniqueCode)
        {
            _context.AddRange(lstUniqueCode);
            await _context.SaveChangesAsync();
            return new ResponseMessage { Message = "Resource Added successfully", statusCode = 200 };
        }
        public async Task<ResponseMessage> ReadData()
        {
            List<UniqueCode> records = await _context.UniqueCodeItems.ToListAsync();
            return new ResponseMessage { statusCode = 200, Data = records };
        }


    }
}