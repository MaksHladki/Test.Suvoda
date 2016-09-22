using System;
using System.Linq;
using System.Web.Mvc;
using MaksimHladki.BusinessLayer.Service.Common;
using MaksimHladki.DAL.Model;
using MaksimHladki.Web.ViewModel;

namespace MaksimHladki.Web.Controllers
{
    public class DrugUnitController : Controller
    {
        private readonly IDepotService _depotService;
        private readonly IDrugUnitService _drugUnitService;

        public DrugUnitController(IDepotService depotService, IDrugUnitService drugUnitService)
        {
            _depotService = depotService;
            _drugUnitService = drugUnitService;
        }
        // GET: DrugUnit
        [HttpGet]
        public ActionResult AssignToDepot()
        {
            var drugUnits = _drugUnitService.GetAllDrugUnits();
            var depots = _depotService.GetAllDepots()
                .Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });

            var viewModel = new DrugUnitAssignViewModel
            {
                DrugUnits = drugUnits
                .Select(AutoMapper.Mapper.Map<DrugUnitViewModel>)
                .ToList(),
                Depots = depots.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignToDepot(DrugUnitAssignViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var drugUnits = viewModel.DrugUnits
                        .Select(AutoMapper.Mapper.Map<DrugUnit>)
                        .ToList();
                    _drugUnitService.AssignDrugUnitToDepot(drugUnits);

                    TempData["messageOk"] = "Your changes were saved successfully";
                    return RedirectToAction("AssignToDepot", "DrugUnit");
                }
                catch (Exception)
                {
                    TempData["messageError"] = "An error was occurred while saving";
                }
            }
            return View(viewModel);
        }
    }
}