using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MaksimHladki.Web.ViewModel
{
    public class DepotCalculateDrugUnitsViewModel
    {
        [Required]
        [Display(Name = "Depot")]
        public int SelectedDepotId { get; set; }
        public List<SelectListItem> Depots { get; set; }
        public List<DrugTypeCountViewModel> DrugTypes { get; set; }
        public List<DrugUnitViewModel> DrugUnits { get; set; }
    }
}