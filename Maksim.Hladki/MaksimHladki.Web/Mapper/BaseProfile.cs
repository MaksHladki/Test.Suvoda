using AutoMapper;

namespace MaksimHladki.Web.Mapper
{
    public abstract class BaseProfile : Profile
    {
        protected BaseProfile(string profileName)
        {
            ProfileName = profileName;
        }

        public override string ProfileName { get; }

        protected override void Configure()
        {
            CreateMaps();
        }

        protected abstract void CreateMaps();
    }
}