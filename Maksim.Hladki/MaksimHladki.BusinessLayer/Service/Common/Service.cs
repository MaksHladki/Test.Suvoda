using System.Data.Entity;
using MaksimHladki.DAL.Common;

namespace MaksimHladki.BusinessLayer.Service.Common
{
    public class Service : IService
    {
        protected IUnitOfWork Uow;

        public Service(DbContext context)
        {
            Uow = new UnitOfWork(context);
        }

        public Service(IUnitOfWork uow)
        {
            Uow = uow;
        }
    }
}