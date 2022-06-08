﻿using Application.Models.DTOs.Requests;
using Application.Models.DTOs.Response;
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

        public (bool Status, string MessageResult) Update(int id, UpdateCustomerRequest customerToUpdateDto);

        public bool Delete(int id);
    }
}