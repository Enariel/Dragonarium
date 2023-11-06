// Dragonarium
// IRepository.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

namespace Dragonarium.Services.Repos
{
    public interface IRepository<T>
    {
        T Get(int id);

        Task<T> GetAsync(int id);

        T Get(string id);

        Task<T> GetAsync(string id);

        T Get(Guid id);

        Task<T> GetAsync(Guid id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        void Add(T entity);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}