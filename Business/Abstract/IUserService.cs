using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaimDto>> GetClaims(int id);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<UserForDetail> GetForUserDetailById(int id);
        IResult UpdateUserInfo(User user);
        IResult Add(User user); 
        IResult Delete(User user);
        IResult Update(User user);
    }
}
