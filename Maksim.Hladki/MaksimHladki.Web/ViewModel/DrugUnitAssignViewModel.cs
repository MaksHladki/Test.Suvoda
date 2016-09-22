using System.Collections.Generic;
using System.Web.Mvc;

namespace MaksimHladki.Web.ViewModel
{
    public class DrugUnitAssignViewModel
    {
        public List<SelectListItem> Depots { get; set; }
        public List<DrugUnitViewModel> DrugUnits { get; set; }
    }
}