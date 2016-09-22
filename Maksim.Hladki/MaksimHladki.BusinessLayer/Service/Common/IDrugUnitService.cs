using System.Collections.Generic;
using MaksimHladki.BusinessLayer.Model;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.BusinessLayer.Service.Common
{
    public interface IDrugUnitService
    {
        List<DrugUnit> GetAllDrugUnits();
        void AssignDrugUnitToDepot(List<DrugUnit> drugUnits);
        List<DrugUnit> GetDrugUnits(DepotCalculateDrugTypeModel model);
    }
}