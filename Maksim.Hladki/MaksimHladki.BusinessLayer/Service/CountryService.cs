using System.Data.Entity;
using MaksimHladki.BusinessLayer.Service.Common;

namespace MaksimHladki.BusinessLayer.Service
{
    public class CountryService : Common.Service, ICountryService
    {
        public CountryService(DbContext context) : base(context)
        {
            
        }
    }
}