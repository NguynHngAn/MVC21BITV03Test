using WWorldMidTest.Data;

namespace WWorldMidTest.Repository.IRepository
{
    public interface ICarRepository : IRepository<Car>
    {
        void Update(Car car);
        void Save();
    }
}
