using WWorldMidTest.Data;

namespace WWorldMidTest.Repository.IRepository
{
    public interface IPartRepository : IRepository<Part>
    {
        void Update(Part part);
        void Save();
    }
}
