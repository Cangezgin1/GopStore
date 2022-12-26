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
    public class StudentLoginManager : IStudentLoginService
    {
        IStudentDal _studentsDal;

        public StudentLoginManager(IStudentDal studentsDal)
        {
            _studentsDal = studentsDal;
        }

        public Students GetStudent(string Name, string SurName, string TC, string OkulNo)
        {
            return _studentsDal.Get(x => x.İsim == Name && x.Soyisim == SurName && x.TCKimlikNumarasi == TC && x.OkulNumarasi == OkulNo);
        }
    }
}
