using MaksimHladki.DAL.Model;
using MaksimHladki.Web.ViewModel;

namespace MaksimHladki.Web.Mapper
{
    public class DepotProfile : BaseProfile
    {
        public DepotProfile() : base("DepotProfile")
        {
        }

        protected override void CreateMaps()
        {
            CreateMap<Depot, DepotViewModel>()
                .ForMember("Country", opt => opt.MapFrom(c => c.Country.Name));
        }
    }
}