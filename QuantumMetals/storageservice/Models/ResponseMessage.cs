namespace storageservice.Models
{
    public class ResponseMessage
    {
        public int statusCode { get; set; }
        public string Message { get; set; }
        public List<UniqueCode> Data { get; set; }
    }
}