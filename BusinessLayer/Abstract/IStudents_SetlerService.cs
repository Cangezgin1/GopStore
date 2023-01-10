using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudents_SetlerService
    {
        List<Students_Setler> GetList();

        void StudentSetlerAdd(Students_Setler users_Setler);
        void StudentSetlerAdd2(Students_Setler users_Setler);
        void StudentSetlerDelete(Students_Setler users_Setler);
        void StudentSetlerUpdate(Students_Setler users_Setler);
        Students_Setler GetById(int? id);
    }
}
