using Microsoft.EntityFrameworkCore;
using SoftwareTestOgSikkerhed.Interfaces;
using SoftwareTestOgSikkerhed.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftwareTestOgSikkerhed.Repositories
{
	public class CprRepository : ICRUD<Cpr>
	{
		Dbcontext context;

        public CprRepository(Dbcontext dbcontext)
        {
			context = dbcontext;
        }

		public async Task AddTodoItemToCpr(Cpr cpr, Todolist todoItem)
		{
			//throw new NotImplementedException();
			if (cpr.Todolist == null)
			{
				cpr.Todolist = new List<Todolist>();
			}

			cpr.Todolist.Add(todoItem);
			await context.SaveChangesAsync();
			return;
		}

        public async Task<Cpr> Create(Cpr model)
		{
			context.Cpr.Add(model);
			await context.SaveChangesAsync();
			return model;
		}

		public async Task<Cpr> Delete(int id)
		{
			Cpr cpr = await GetById(id);
			if (cpr != null)
			{
				context.Remove(cpr);
				await context.SaveChangesAsync();
			}
			return cpr;
		}

		public async Task<List<Cpr>> GetAll()
		{
			return await context.Cpr.Include(x => x.Todolist)
				.ToListAsync();
		}

		public async Task<Cpr> GetById(int id)
		{
			return await context.Cpr.FirstAsync(x => x.Id == id);
		}

		public async Task<Cpr?> Update(Cpr model)
		{
			throw new NotImplementedException();
		}
	}
}
