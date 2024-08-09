using WWorldMidTest.Data;
using WWorldMidTest.Repository.IRepository;

namespace WWorldMidTest.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private CarDealerContext _db;
        public CarRepository(CarDealerContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Car car)
        {
            _db.Cars.Update(car);
        }
    }

}
