using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductsManager : IProductsService
    {
        IProductsDal _productsDal;

        public ProductsManager(IProductsDal productsDal)
        {
            _productsDal = productsDal;
        }

        public Products GetById(int id)
        {
            return _productsDal.Get(x=>x.ÜrünID==id);
        }

        public List<Products> GetList()
        {
            return _productsDal.List();
        }

        public void ÜrünAdd(Products products)
        {
            _productsDal.Insert(products);
        }

        public void ÜrünDelete(Products products)
        {
            _productsDal.Delete(products);
        }

        public void ÜrünUpdate(Products products)
        {
            _productsDal.Update(products);
        }
    }
}
