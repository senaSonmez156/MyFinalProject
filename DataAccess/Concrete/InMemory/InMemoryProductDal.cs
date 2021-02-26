using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitInStock=5, UnitPrice=10},
            new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitInStock=500, UnitPrice=15},
            new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitInStock=1500, UnitPrice=17},
            new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitInStock=150, UnitPrice=8},
            new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitInStock=65, UnitPrice=6},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
