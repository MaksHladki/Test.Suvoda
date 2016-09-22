using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MaksimHladki.BusinessLayer.Model;
using MaksimHladki.BusinessLayer.Service.Common;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.BusinessLayer.Service
{
    public class DepotService : Common.Service, IDepotService
    {
        public DepotService(DbContext context) : base(context)
        {

        }
        public List<Depot> GetAllDepots()
        {
            var depots = Uow.DepotRepository.GetAll();
            return depots.ToList();
        }

        public List<DepotGroupModel> GetDepotGroups()
        {
            var groups = new List<DepotGroupModel>();
            var depots = Uow.DepotRepository.GetAll();
            var depotIds = depots.Select(d => d.Id);
            var drugUnitGroups = Uow.DrugUnitRepository
                .GetByDepotId(depotIds.ToArray())
                .GroupBy(du => du.DepotId);

            foreach (var depot in depots)
            {
                var group = new DepotGroupModel
                {
                    Depot = depot
                };

                var drugUnitGroup = drugUnitGroups.FirstOrDefault(dug => dug.Key == depot.Id);
                if (drugUnitGroup != null)
                {
                    group.DrugUnits = drugUnitGroup.ToList();
                }

                groups.Add(group);
            }

            return groups;
        }
    }
}