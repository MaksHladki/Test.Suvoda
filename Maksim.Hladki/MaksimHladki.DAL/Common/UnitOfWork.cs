using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using MaksimHladki.DAL.Repository;

namespace MaksimHladki.DAL.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICountryRepository _countryRepository;
        private DbContext _dbContext;
        private IDepotRepository _depotRepository;
        private bool _disposed;
        private IDrugTypeRepository _drugTypeRepository;
        private IDrugUnitRepository _drugUnitRepository;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
            _disposed = false;
        }

        public ICountryRepository CountryRepository
        {
            get { return _countryRepository ?? (_countryRepository = new CountryRepository(_dbContext)); }
        }

        public IDepotRepository DepotRepository
        {
            get { return _depotRepository ?? (_depotRepository = new DepotRepository(_dbContext)); }
        }

        public IDrugUnitRepository DrugUnitRepository
        {
            get { return _drugUnitRepository ?? (_drugUnitRepository = new DrugUnitRepository(_dbContext)); }
        }

        public IDrugTypeRepository DrugTypeRepository
        {
            get { return _drugTypeRepository ?? (_drugTypeRepository = new DrugTypeRepository(_dbContext)); }
        }

        public void Commit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = $"{validationErrors.Entry.Entity}:{validationError.ErrorMessage}";
                        raise = new InvalidOperationException(message, raise);
                    }
                }

                Rollback();
                throw raise;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
            _disposed = true;
        }

        private void Rollback()
        {
            var dbContext = _dbContext;
            var manager = ((IObjectContextAdapter) dbContext).ObjectContext.ObjectStateManager;

            foreach (var entry in manager.GetObjectStateEntries(EntityState.Added).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter) dbContext).ObjectContext.DeleteObject(entry.Entity);
            }

            foreach (
                var entry in manager.GetObjectStateEntries(EntityState.Unchanged).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter) dbContext).ObjectContext.Refresh(RefreshMode.StoreWins, entry.Entity);
            }

            foreach (
                var entry in manager.GetObjectStateEntries(EntityState.Modified).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter) dbContext).ObjectContext.Refresh(RefreshMode.StoreWins, entry.Entity);
            }

            foreach (
                var entry in manager.GetObjectStateEntries(EntityState.Deleted).Where(entry => entry.Entity != null))
            {
                ((IObjectContextAdapter) dbContext).ObjectContext.Refresh(RefreshMode.StoreWins, entry.Entity);
            }

            ((IObjectContextAdapter) dbContext).ObjectContext.AcceptAllChanges();
        }
    }
}