using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
       public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
       {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cc in context.Colors
                             on c.ColorId equals cc.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = cc.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 ImagePath = c.CarImages.FirstOrDefault(p => p.IsMain).ImagePath
                             };

                return result.ToList();
            }
       }

       public CarForDetailDto GetForCarDetails(Expression<Func<Car, bool>> filter = null)
       {
           using (CarRentalContext context = new CarRentalContext())
           {
               var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                   join b in context.Brands
                       on c.BrandId equals b.Id
                   join cc in context.Colors
                       on c.ColorId equals cc.Id
                   join i in context.CarImages
                       on c.Id equals i.CarId
                   select new CarForDetailDto()
                   {
                       Id = c.Id,
                       BrandName = b.Name,
                       ColorName = cc.Name,
                       DailyPrice = c.DailyPrice,
                       ModelYear = c.ModelYear,
                       Description = c.Description,
                       CarImages = c.CarImages
                   };
               return result.FirstOrDefault();
           }
       }
    }
}
