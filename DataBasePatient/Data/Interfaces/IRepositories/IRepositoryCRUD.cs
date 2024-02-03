

namespace DatabaseCookingCoolR6.Data.Interfaces.IRepositories
{
    //Common CRUD
    public interface IRepositoryCRUD<T>
    {
        //Get List of items
        public Task<IEnumerable<T>> GetListAsync();

        //Get item by id
        public Task<T> GetByIdAsync(Guid id);

        //Create item
        //Returns Id of item
        public Task<Guid> CreateAsync(T item);

        //Update item
        //Returns success of operation
        public Task<bool> UpdateAsync(T item);

        //Delete item
        //Returns success of operation
        public Task<bool> DeleteAsync(Guid id);
    }
}
