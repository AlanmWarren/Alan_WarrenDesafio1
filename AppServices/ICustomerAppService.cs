using Application.Models.Requests;
using Application.Models.Response;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application.Validators
{
    public interface ICustomerAppService
    {
        IEnumerable<CustomerResult> GetAll(Func<Customer, bool> predicate = null);

        CustomerResult GetBy(Func<Customer, bool> predicate);

        public int Create(CreateCustomerRequest newCustomerDto);

        public (bool status, string messageResult) Update(int id, UpdateCustomerRequest customerToUpdateDto);

        public bool Delete(int id);
    }
}