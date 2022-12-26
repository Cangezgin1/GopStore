using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStudentLoginService
    {
        Students GetStudent(string Name, string SurName,string TC,string OkulNo);
    }
}
