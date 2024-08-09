using WWorldMidTest.Data;

namespace WWorldMidTest.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer customer);
        void Save();
    }
}
