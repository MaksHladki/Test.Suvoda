using System.Collections.Generic;

namespace MaksimHladki.Web.ViewModel
{
    public class DepotGroupViewModel
    {
        public DepotViewModel Depot { get; set; }
        public List<DrugUnitViewModel> DrugUnits { get; set; }
    }
}