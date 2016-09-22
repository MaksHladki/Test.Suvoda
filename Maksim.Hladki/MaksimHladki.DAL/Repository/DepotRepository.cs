using System.Data.Entity;
using MaksimHladki.DAL.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.DAL.Repository
{
    internal sealed class DepotRepository : Repository<Depot>, IDepotRepository
    {
        public DepotRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}