using AutoMapper;
using Test_Shop.Entities.Models;
using Test_Shop.Infrastructure.Interfaces.Mappings;

namespace Test_Shop.UseCases.Handlers.Dto
{
    public class OrderDto 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>()
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.FirstName,
                    opt => opt.MapFrom(note => note.FirstName))
                .ForMember(noteDto => noteDto.LastName,
                    opt => opt.MapFrom(note => note.LastName))
                .ForMember(noteDto => noteDto.Address,
                    opt => opt.MapFrom(note => note.Address))
                .ForMember(noteDto => noteDto.City,
                    opt => opt.MapFrom(note => note.City))
                .ForMember(noteDto => noteDto.Email,
                    opt => opt.MapFrom(note => note.Email))
                .ForMember(noteDto => noteDto.Country,
                    opt => opt.MapFrom(note => note.Country))
                .ForMember(noteDto => noteDto.TotalPrice,
                    opt => opt.MapFrom(note => note.TotalPrice));
        }
    }
}
