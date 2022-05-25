using Alan_WarrenDesafio1.Models;
using Application.DTOs;
using AutoMapper;

namespace AppServices
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, ReadCustomerDto>();

            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
