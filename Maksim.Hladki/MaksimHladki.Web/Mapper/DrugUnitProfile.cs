using MaksimHladki.DAL.Model;
using MaksimHladki.Web.ViewModel;

namespace MaksimHladki.Web.Mapper
{
    public class DrugUnitProfile : BaseProfile
    {
        public DrugUnitProfile() : base("DrugUnitProfile")
        {
        }

        protected override void CreateMaps()
        {
            CreateMap<DrugUnit, DrugUnitViewModel>();
            CreateMap<DrugUnitViewModel, DrugUnit>();
        }
    }
}