﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

       public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
            
        {
            if (product.ProductName.Length<2)

            {
                return new ErorResult(Messages.ProductNameİnvalid);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }

        public IDataResult<List<Product>> GetAll()

        {
            if (DateTime.Now.Hour==22)
            {
                return new ErorDataResult();
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), true, "Ürünler listelendi.");
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int ProductId)
        {
            return _productDal.Get(p=>p.ProductId == ProductId);
        }

        public List<Product> GetByUnitsPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice <= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
