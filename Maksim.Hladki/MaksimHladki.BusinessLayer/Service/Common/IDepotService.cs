using System.Collections.Generic;
using MaksimHladki.BusinessLayer.Model;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.BusinessLayer.Service.Common
{
    public interface IDepotService : IService
    {
        List<Depot> GetAllDepots();
        List<DepotGroupModel> GetDepotGroups();
    }
}