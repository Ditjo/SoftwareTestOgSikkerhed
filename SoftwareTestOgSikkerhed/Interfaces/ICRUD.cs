namespace SoftwareTestOgSikkerhed.Interfaces
{
	public interface ICRUD<T>
	{
		Task<List<T>> GetAll();
		Task<T> GetById(int id);
		Task<T> Create(T model);
		Task<T?> Update(T model);
		Task<T> Delete(int id);
	}
}
