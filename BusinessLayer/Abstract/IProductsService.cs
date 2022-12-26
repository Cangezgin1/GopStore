using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductsService
    {
        List<Products> GetList();

        void ÜrünAdd(Products products);

        void ÜrünDelete(Products products);

        void ÜrünUpdate(Products products);

        Products GetById(int id);
    }
}
