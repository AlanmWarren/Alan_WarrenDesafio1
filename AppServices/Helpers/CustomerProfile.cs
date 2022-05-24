using Alan_WarrenDesafio1.Models;
using AutoMapper;

namespace AppServices
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ReverseMap();
        }
    }
}
