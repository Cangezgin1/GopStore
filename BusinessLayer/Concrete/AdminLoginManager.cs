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
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminsDal _adminsDal;

        public AdminLoginManager(IAdminsDal adminsDal)
        {
            _adminsDal = adminsDal;
        }

        public Admins GetAdmin(string mail, string password)
        {
            return _adminsDal.Get(x=>x.AdminMail==mail && x.AdminŞifre == password);
        }
    }
}
