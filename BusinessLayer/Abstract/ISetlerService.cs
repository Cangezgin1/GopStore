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

        void WriterAdd(Setler setler);

        void WriterDelete(Setler setler);

        void WriterUpdate(Setler setler);

        Setler GetById(int id);
    }
}
