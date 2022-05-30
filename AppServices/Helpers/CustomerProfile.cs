using Alan_WarrenDesafio1.DomainModels;
using Application.DTOs;
using AutoMapper;

namespace AppServices
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResult>();

            CreateMap<CreateCustomerRequest, Customer>();

            CreateMap<UpdateCustomerRequest, Customer>();
        }
    }
}