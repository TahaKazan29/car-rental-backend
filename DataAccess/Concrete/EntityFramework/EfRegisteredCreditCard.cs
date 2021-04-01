using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRegisteredCreditCard:EfEntityRepositoryBase<RegisteredCreditCard,CarRentalContext>,IRegisteredCreditCardDal
    {
        //public List<RegisteredCreditCardDto> RegisteredCreditCart(Expression<Func<RegisteredCreditCard, bool>> filter = null)
        //{
        //    using (CarRentalContext context = new CarRentalContext())
        //    {
        //        var result = from c in filter == null ? context.RegisteredCreditCards : context.RegisteredCreditCards.Where(filter)
        //            join r in context.Rentals
        //                on c.CustomerId equals r.CustomerId
        //            join b in context.Banks
        //                on r.Id equals b.RentId
        //            select new RegisteredCreditCardDto()
        //            {
        //               Id = c.Id,
        //               NameOnTheCard = b.NameOnTheCard,
        //               CVV = b.CVV,
        //               CardNumber = b.CardNumber,
        //               ExpirationDate = b.ExpirationDate
        //            };

        //        return result.ToList();
        //    }
        //}
    }
}
