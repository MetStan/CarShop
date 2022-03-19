using System.Linq;

namespace CarShop.Services.Contracts
{
    public interface IDBaseService<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        int SaveChanges();
    }
}
