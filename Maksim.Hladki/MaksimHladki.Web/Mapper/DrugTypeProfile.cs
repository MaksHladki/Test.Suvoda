using MaksimHladki.BusinessLayer.Model;
using MaksimHladki.DAL.Model;
using MaksimHladki.Web.ViewModel;

namespace MaksimHladki.Web.Mapper
{
    public class DrugTypeProfile : BaseProfile
    {
        public DrugTypeProfile() : base("DrugTypeProfile")
        {
        }

        protected override void CreateMaps()
        {
            CreateMap<DrugType, DrugTypeViewModel>();
            CreateMap<DrugTypeViewModel, DrugType>();
            CreateMap<DrugTypeCountViewModel, DepotCalculateDrugTypeItemModel>();
            CreateMap<DrugType, DrugTypeCountViewModel>();
        }
    }
}