using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentsService
    {
        List<Students> GetList();

        void StudentAdd(Students users);
        
        void StudentDelete(Students users);
        
        void StudentUpdate(Students users);

        Students GetById(int id);
    }
}
