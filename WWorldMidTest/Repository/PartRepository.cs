using WWorldMidTest.Data;
using WWorldMidTest.Repository.IRepository;

namespace WWorldMidTest.Repository
{
    public class PartRepository : Repository<Part>, IPartRepository
    {
        private CarDealerContext _db;
        public PartRepository(CarDealerContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Part part)
        {
            _db.Parts.Update(part);
        }
    }
}
