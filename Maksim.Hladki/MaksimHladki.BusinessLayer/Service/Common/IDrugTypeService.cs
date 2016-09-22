using System.Collections.Generic;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.BusinessLayer.Service.Common
{
    public interface IDrugTypeService : IService
    {
        List<DrugType> GetAllDrugTypes();
    }
}