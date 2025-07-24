using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _iProductDal;
        ICategoryService _iCategoryService;
        private object CategoryCountError;

        public ProductManager(IProductDal productDal, ICategoryService categoryservice)
        {
            _iProductDal = productDal;
            _iCategoryService = categoryservice;
        }

        [ValidationAspect(typeof(ProductValidator))]

        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName),CheckCategoryCount());
           
            if (result != null)
            {
                return result;
            }
            _iProductDal.Add(product);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(), "Ürünler Listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(p => p.CategoryId == id));

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_iProductDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_iProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_iProductDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _iProductDal.GetAll(p => p.ProductId == product.ProductId);
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _iProductDal.GetAll(p => p.CategoryId == categoryId);
            if (result.Count <= 10)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ProductCountByCategoryError);
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _iProductDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult CheckCategoryCount()
        {
            var result = _iCategoryService.GetAll();

            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryCountError);
            }
            return new SuccessResult();
        }
    }
}
