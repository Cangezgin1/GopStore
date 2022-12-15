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
    public class SetlerManager : ISetlerService
    {
        ISetlerDal _setlerDal;

        public SetlerManager(ISetlerDal setlerDal)
        {
            _setlerDal = setlerDal;
        }

        public Setler GetById(int id)
        {
            return _setlerDal.Get(x=>x.SetID == id);
        }

        public List<Setler> GetList()
        {
            return _setlerDal.List();
        }

        public void WriterAdd(Setler setler)
        {
            _setlerDal.Insert(setler);
        }

        public void WriterDelete(Setler setler)
        {
            _setlerDal.Delete(setler);
        }

        public void WriterUpdate(Setler setler)
        {
            _setlerDal.Update(setler);
        }
    }
}
