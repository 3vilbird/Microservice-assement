using codegeneratorservice.Model;

namespace codegeneratorservice.Service
{
    public interface IUniqueCodeGenerator
    {
        public Task<ResponseMessage> GenerateUniqueCode(int intCount);

    }
}