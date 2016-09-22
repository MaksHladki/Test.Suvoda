using System;

namespace MaksimHladki.DAL.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ICountryRepository CountryRepository { get; }
        IDepotRepository DepotRepository { get; }
        IDrugUnitRepository DrugUnitRepository { get; }
        IDrugTypeRepository DrugTypeRepository { get; }
        void Commit();
    }
}