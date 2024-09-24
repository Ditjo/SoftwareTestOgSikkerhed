using Microsoft.EntityFrameworkCore;

namespace SoftwareTestOgSikkerhed.Models
{
    public class Dbcontext : DbContext
    {
		public Dbcontext(DbContextOptions<Dbcontext> option) : base(option)
		{
			// if I want a direct access to db, I write it here (like Program.cs)
		}

		DbSet<Cpr> Cprs { get; set; }
		DbSet<Todolist> Todolist { get; set; }
	}
}
