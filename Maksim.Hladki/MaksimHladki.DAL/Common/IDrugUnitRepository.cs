using System.Collections.Generic;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.DAL.Common
{
    public interface IDrugUnitRepository : IRepository<DrugUnit>
    {
        IEnumerable<DrugUnit> GetByDepotId(params int[] depotIds);
    }
}