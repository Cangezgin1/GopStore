using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminsService
    {
        List<Admins> GetList();

        void AdminAdd(Admins admins);

        void AdminDelete(Admins admins);

        void AdminUpdate(Admins admins);

        Admins GetById(int? id);
    }
}
