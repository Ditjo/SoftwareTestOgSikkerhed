using SoftwareTestOgSikkerhed.Interfaces;
using SoftwareTestOgSikkerhed.Models;

namespace SoftwareTestOgSikkerhed.Repositories
{
	public class TodolistRepository : ICRUD<Todolist>
	{
		public Task<Todolist> Create(Todolist model)
		{
			throw new NotImplementedException();
		}

		public Task<Todolist> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Todolist>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Todolist> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Todolist?> Update(Todolist model)
		{
			throw new NotImplementedException();
		}
	}
}
