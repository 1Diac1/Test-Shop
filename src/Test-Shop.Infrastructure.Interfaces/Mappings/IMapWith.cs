using AutoMapper;

namespace Test_Shop.Infrastructure.Interfaces.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
