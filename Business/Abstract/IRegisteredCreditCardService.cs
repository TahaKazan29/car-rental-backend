using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRegisteredCreditCardService
    {
        IResult Add(RegisteredCreditCard registeredCreditCard);
        IResult Delete(RegisteredCreditCard registeredCreditCard);
        IDataResult<List<RegisteredCreditCard>> GetCustomerByRegisteredCreditCard(int customerId);
        IDataResult<List<RegisteredCreditCard>> GetCustomersByRegisteredCreditCard();
    }
}
