using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISetlerService
    {
        List<Setler> GetList();

        void SetAdd(Setler setler);

        void SetDelete(Setler setler);

        void SetUpdate(Setler setler);

        Setler GetById(int? id);
    }
}
