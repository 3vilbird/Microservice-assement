using Microsoft.EntityFrameworkCore;
using storageservice.Models;

namespace storageservice.UniqueCodeContext
{
    public class UniquecodeContext : DbContext
    {
        public UniquecodeContext(DbContextOptions options) : base(options) { }
        public DbSet<UniqueCode> UniqueCodeItems { get; set; }
    }
}