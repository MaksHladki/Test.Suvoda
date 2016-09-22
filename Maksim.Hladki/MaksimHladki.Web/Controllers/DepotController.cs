using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaksimHladki.BusinessLayer.Model;
using MaksimHladki.BusinessLayer.Service.Common;
using MaksimHladki.Web.ViewModel;

namespace MaksimHladki.Web.Controllers
{
    public class DepotController : Controller
    {
        readonly IDepotService _depotService;
        readonly IDrugTypeService _drugTypeService;
        readonly IDrugUnitService _drugUnitService;
     
        public DepotController(IDrugTypeService drugTypeService, IDrugUnitService drugUnitService, IDepotService depotService)
        {
            _drugTypeService = drugTypeService;
            _drugUnitService = drugUnitService;
            _depotService = depotService;
        }
        // GET: Depot
        public ActionResult Index()
        {
            var viewModel = new DepotListViewModel();
            var groups = new List<DepotGroupViewModel>();
            var depotGroups = _depotService.GetDepotGroups();

            foreach (var depotGroupReadModel in depotGroups)
            {
                groups.Add(new DepotGroupViewModel
                {
                    Depot = AutoMapper.Mapper.Map<DepotViewModel>(depotGroupReadModel.Depot),
                    DrugUnits =
                        depotGroupReadModel.DrugUnits?
                        .Select(AutoMapper.Mapper.Map<DrugUnitViewModel>)
                        .ToList()
                        ?? new List<DrugUnitViewModel>()
                });
            }

            viewModel.Groups = groups;
            return View(viewModel);
        }


        [HttpGet]
        public ActionResult CalculateDrugUnit()
        {
            var depots = _depotService.GetAllDepots().Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });

            var drugTypes = _drugTypeService.GetAllDrugTypes();

            var viewModel = new DepotCalculateDrugUnitsViewModel
            {
                Depots = depots.ToList(),
                DrugTypes = drugTypes
                .Select(AutoMapper.Mapper.Map<DrugTypeCountViewModel>)
                .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CalculateDrugUnit(DepotCalculateDrugUnitsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var drugTypeCountModel = viewModel.DrugTypes
                    .Select(AutoMapper.Mapper.Map<DepotCalculateDrugTypeItemModel>)
                    .ToList();

                var model = new DepotCalculateDrugTypeModel
                {
                    DepotId = viewModel.SelectedDepotId,
                    DrugTypes = drugTypeCountModel
                };

                var drugUnits = _drugUnitService.GetDrugUnits(model);
                viewModel.DrugUnits = drugUnits
                    .Select(AutoMapper.Mapper.Map<DrugUnitViewModel>)
                    .ToList();
            }

            return View(viewModel);
        }
    }
}