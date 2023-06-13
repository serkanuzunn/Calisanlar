using Calisanlar.Models;
using Microsoft.EntityFrameworkCore;

namespace Calisanlar.Data
{
    public class CalisanContext:DbContext
    {
        public CalisanContext(DbContextOptions<CalisanContext> options) : base(options) 
        {


        }


        public DbSet<Calisan> Calisanlar { get; set; }
    }
}
