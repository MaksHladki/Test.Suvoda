using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MaksimHladki.BusinessLayer.Service.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.BusinessLayer.Service
{
    public class DrugTypeService : Common.Service, IDrugTypeService
    {
        public DrugTypeService(DbContext context) : base(context)
        {

        }
        public List<DrugType> GetAllDrugTypes()
        {
            return Uow.DrugTypeRepository.GetAll().ToList();
        }
    }
}