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

        void WriterAdd(Admins admins);

        void WriterDelete(Admins admins);

        void WriterUpdate(Admins admins);

        Admins GetById(int id);
    }
}
