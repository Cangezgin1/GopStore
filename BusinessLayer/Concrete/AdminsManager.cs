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
    public class AdminsManager : IAdminsService
    {
        IAdminsDal _adminsDal;

        public AdminsManager(IAdminsDal adminsDal)
        {
            _adminsDal = adminsDal;
        }

        public Admins GetById(int id)
        {
            return _adminsDal.Get(x=>x.AdminID == id);
        }

        public List<Admins> GetList()
        {
            return _adminsDal.List();
        }

        public void WriterAdd(Admins admins)
        {
            _adminsDal.Insert(admins);
        }

        public void WriterDelete(Admins admins)
        {
            _adminsDal.Delete(admins);
        }

        public void WriterUpdate(Admins admins)
        {
            _adminsDal.Update(admins);
        }
    }
}
