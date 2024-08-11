using AgendaOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaOnline.Data
{
    public class AplicationDBContext : DbContext
    {

        public AplicationDBContext(DbContextOptions<AplicationDBContext> option) : base(option)
        {

        }

        public DbSet<AgendaModel> Agenda { get; set; }
    }
}
