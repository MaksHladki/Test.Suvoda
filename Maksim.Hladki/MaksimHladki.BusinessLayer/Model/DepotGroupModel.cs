using System.Collections.Generic;
using MaksimHladki.DAL.Model;

namespace MaksimHladki.BusinessLayer.Model
{
    public sealed class DepotGroupModel
    {
        public Depot Depot { get; set; }
        public List<DrugUnit> DrugUnits { get; set; }
    }
}