using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,CarRentalContext>, IUserDal
    {
        public List<OperationClaimDto> GetClaims(int id)
        {
            using (var context = new CarRentalContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == id
                    select new OperationClaimDto
                    {
                        Id = operationClaim.Id,
                        Name = operationClaim.Name
                    };
                return result.ToList();
            }
        }

        public UserForDetail GetForUserDetailById(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new CarRentalContext())
            {
                var result = from user in filter == null ? context.Users : context.Users.Where(filter)
                    select new UserForDetail
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        
                    };
                return result.FirstOrDefault();
            }
        }
    }
}
