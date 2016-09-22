using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MaksimHladki.BusinessLayer.Model;
using MaksimHladki.BusinessLayer.Service.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.BusinessLayer.Service
{
    public class DrugUnitService : Common.Service, IDrugUnitService
    {
        public DrugUnitService(DbContext context) : base(context)
        {

        }
        public List<DrugUnit> GetAllDrugUnits()
        {
            return Uow.DrugUnitRepository.GetAll().ToList();
        }

        public void AssignDrugUnitToDepot(List<DrugUnit> drugUnits)
        {
            var dbDrugUnits = Uow.DrugUnitRepository.GetAll();
            foreach (var dbDrugUnit in dbDrugUnits)
            {
                var drugUnit = drugUnits.FirstOrDefault(du => du.Id == dbDrugUnit.Id);
                if (drugUnit == null || dbDrugUnit.DepotId == drugUnit.DepotId)
                    continue;

                dbDrugUnit.DepotId = drugUnit.DepotId;
                Uow.DrugUnitRepository.Update(dbDrugUnit);
            }

            Uow.Commit();
        }

        public List<DrugUnit> GetDrugUnits(DepotCalculateDrugTypeModel model)
        {
            var resultDu = new List<DrugUnit>();
            var drugUnitGroups = Uow.DrugUnitRepository.GetByDepotId(model.DepotId).GroupBy(du => du.DrugTypeId);


            foreach (var group in drugUnitGroups)
            {
                var drugType = model.DrugTypes.FirstOrDefault(dt => dt.Id == group.Key);

                var count = drugType?.Count ?? 0;
                if (count <= 0)
                    continue;

                foreach (var drugUnit in group.ToList())
                {
                    if (drugUnit.PickNumber >= count)
                    {
                        drugUnit.PickNumber = count;
                        resultDu.Add(drugUnit);
                        break;
                    }

                    if (drugUnit.PickNumber > 0)
                    {
                        count -= drugUnit.PickNumber;
                        resultDu.Add(drugUnit);
                    }

                    if (count == 0)
                        break;
                }
            }

            return resultDu;
        }
    }
}