using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BankManager : IBankService
    {

        private readonly IBankDal _bankDal;

        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }

        public IResult Add(BankDto bankDto)
        {
            Bank bankAdded = new Bank()
            {
                RentId = bankDto.RentId,
                NameOnTheCard = bankDto.NameOnTheCard,
                CardNumber = bankDto.CardNumber,
                CVV = bankDto.CVV,
                ExpirationDate = bankDto.ExpirationDate
            };

            _bankDal.Add(bankAdded);
            return new SuccessResult(Messages.BankSuccess);

        }

        public IDataResult<List<Bank>> GetAll()
        {
            return new SuccessDataResult<List<Bank>>(_bankDal.GetAll());
        }
    }
}
