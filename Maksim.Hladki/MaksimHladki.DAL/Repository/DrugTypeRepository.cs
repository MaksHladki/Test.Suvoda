using System.Data.Entity;
using MaksimHladki.DAL.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.DAL.Repository
{
    internal sealed class DrugTypeRepository : Repository<DrugType>, IDrugTypeRepository
    {
        public DrugTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}