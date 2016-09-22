using System.Data.Entity;
using MaksimHladki.DAL.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.DAL.Repository
{
    internal sealed class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}