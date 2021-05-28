using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager:IUserOperationClaimService
    {
        private IUserOperationClaimDal _operationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("admin")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            var result = BusinessRule.Run(CheckClaim(userOperationClaim));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _operationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.Authorized);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_operationClaimDal.GetAll());
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_operationClaimDal.Get(c => c.Id == id));
        }

        public IResult CheckClaim(UserOperationClaim userOperationClaim)
        {
            var result = _operationClaimDal.Get(c =>
                c.OperationClaimId == userOperationClaim.OperationClaimId && c.UserId == userOperationClaim.UserId);
            if (result != null)
            {
                return new ErrorResult(Messages.AuthorizationError);
            }

            return new SuccessResult();
        }
    }
}
