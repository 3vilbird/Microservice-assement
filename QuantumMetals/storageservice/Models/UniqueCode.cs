using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace storageservice.Models
{
    [Table("UniqueCode")]
    public class UniqueCode
    {
        [Key]
        public int intCodeId { get; set; }
        public string strUniqueCode { get; set; }
    }
}