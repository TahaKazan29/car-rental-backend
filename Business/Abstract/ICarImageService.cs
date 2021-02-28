using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IDataResult<CarImage> Get(int id);
        IResult Add(IFormFile formFile,CarImage carImage);
        IResult Update(IFormFile formFile,CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
