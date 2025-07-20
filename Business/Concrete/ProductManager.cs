using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _iProductDal;
        public ProductManager(IProductDal productDal)
        {
            _iProductDal = productDal;
        }

        public IResult Add(Product product)
        {
            if(product.ProductName.Length<2)
            {
                return new ErrorResult("Ürün adı 2 karakterden büyük olmalı");
            }
            _iProductDal.Add(product);
            return new SuccessResult("İşlem Başarılı");
        }

        public List<Product> GetAll()
        {
            return _iProductDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _iProductDal.GetAll(p=>p.CategoryId==id);

        }

        public Product GetById(int productId)
        {
            return _iProductDal.Get(p=> p.ProductId==productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _iProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _iProductDal.GetProductDetails();
        }
    }
}
