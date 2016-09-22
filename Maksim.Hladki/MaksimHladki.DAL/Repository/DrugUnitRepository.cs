using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MaksimHladki.DAL.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.DAL.Repository
{
    internal sealed class DrugUnitRepository : Repository<DrugUnit>, IDrugUnitRepository
    {
        public DrugUnitRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<DrugUnit> GetByDepotId(params int[] depotIds)
        {
            var tmpdepotIds = depotIds.ToList();
            var drugUnits = DbSet.Where(du => du.DepotId.HasValue && tmpdepotIds.Contains(du.DepotId.Value));

            return drugUnits;
        }
    }
}