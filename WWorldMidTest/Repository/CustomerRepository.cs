using WWorldMidTest.Data;
using WWorldMidTest.Repository.IRepository;

namespace WWorldMidTest.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private CarDealerContext _db;
        public CustomerRepository(CarDealerContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _db.Customers.Update(customer);
        }
    }
}
