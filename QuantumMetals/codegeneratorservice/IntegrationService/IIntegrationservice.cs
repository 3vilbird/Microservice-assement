using codegeneratorservice.Model;

namespace codegeneratorservice.IntegrationService
{
    public interface IIntegrationservice
    {
        public Task<ResponseMessage> GetData();
        public Task<ResponseMessage> AddCodeToStorage(List<UniqueCodeDTO> lstUniqueCode);
    }
}