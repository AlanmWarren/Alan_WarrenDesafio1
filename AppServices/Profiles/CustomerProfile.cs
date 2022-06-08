using Application.Models.DTOs.Requests;
using Application.Models.DTOs.Response;
using AutoMapper;
using Domain.Models;

namespace Application.Profiles
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