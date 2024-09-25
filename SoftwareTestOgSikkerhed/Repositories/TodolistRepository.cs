using Microsoft.EntityFrameworkCore;
using SoftwareTestOgSikkerhed.Interfaces;
using SoftwareTestOgSikkerhed.Models;

namespace SoftwareTestOgSikkerhed.Repositories
{
	public class TodolistRepository : ICRUD<Todolist>
	{
		Dbcontext context;

		public TodolistRepository(Dbcontext dbcontext)
		{
			context = dbcontext;
		}

		public async Task<Todolist> Create(Todolist model)
		{
			context.Todolist.Add(model);
			await context.SaveChangesAsync();
			return model;
		}

		public async Task<Todolist> Delete(int id)
		{
			Todolist todo = await GetById(id);
			if (todo != null)
			{
				context.Remove(todo);
				await context.SaveChangesAsync();
			}
			return todo;
		}

		public async Task<List<Todolist>> GetAll()
		{
			return await context.Todolist.ToListAsync();
		}

		public async Task<Todolist> GetById(int id)
		{
			return await context.Todolist.FirstAsync(x => x.Id == id);
		}

		public async Task<Todolist?> Update(Todolist model)
		{
			throw new NotImplementedException();
		}
	}
}
