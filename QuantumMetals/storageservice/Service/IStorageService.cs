using storageservice.Models;

namespace storageservice.Service
{
    public interface IStorageService
    {
        public Task<ResponseMessage> AddData(List<UniqueCode> lstUniqueCode);
        public Task<ResponseMessage> ReadData();
    }
}