using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RegisteredCreditCardManager:IRegisteredCreditCardService
    {
        private IRegisteredCreditCardDal _registeredCreditCardDal;

        public RegisteredCreditCardManager(IRegisteredCreditCardDal registeredCreditCardDal)
        {
            _registeredCreditCardDal = registeredCreditCardDal;
        }

        public IResult Add(RegisteredCreditCard registeredCreditCard)
        {
            _registeredCreditCardDal.Add(registeredCreditCard);
            return new SuccessResult();
        }

        public IDataResult<List<RegisteredCreditCard>> GetCustomerByRegisteredCreditCard(int customerId)
        {
            var result = _registeredCreditCardDal.GetAll(c => c.CustomerId == customerId);
            return new SuccessDataResult<List<RegisteredCreditCard>>(result);
        }

        public IDataResult<List<RegisteredCreditCard>> GetCustomersByRegisteredCreditCard()
        {
            var result = _registeredCreditCardDal.GetAll();
            return new SuccessDataResult<List<RegisteredCreditCard>>(result);
        }

        public IResult Delete(RegisteredCreditCard registeredCreditCard)
        {
            _registeredCreditCardDal.Delete(registeredCreditCard);
            return new SuccessResult();
        }
    }
}
