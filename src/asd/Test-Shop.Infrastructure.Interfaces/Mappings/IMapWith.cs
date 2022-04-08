using AutoMapper;


namespace Test_Shop.Infrastructure.Interfaces.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
