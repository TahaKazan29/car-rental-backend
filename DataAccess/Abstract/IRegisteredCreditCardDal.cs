using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text; 
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRegisteredCreditCardDal:IEntityRepository<RegisteredCreditCard>
    {
        //List<RegisteredCreditCardDto> RegisteredCreditCart(Expression<Func<RegisteredCreditCard, bool>> filter = null);
    }
}
