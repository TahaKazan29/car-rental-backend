using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttinConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<Car> Add(Car car)
        {
            var result = BusinessRule.Run();
            _carDal.Add(car);
            return new SuccessDataResult<Car>(car,Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        [CacheAspect()]
        public IDataResult<List<Car>> GetAll()
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        //public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        //}

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId));
        }

        //public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        //}

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByFilter(int? brandId,int? colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByFilter(brandId, colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<CarForDetailDto> GetForCarDetails(int id)
        {
            return new SuccessDataResult<CarForDetailDto>(_carDal.GetForCarDetails(c => c.Id == id));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        //private IResult CheckNullImage()
        //{

        //}

    }
}
