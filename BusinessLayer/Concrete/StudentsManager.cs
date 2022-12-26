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
    public class StudentsManager : IStudentsService
    {
        IUsersDal _usersDal;
        IStudents_SetlerDal _students_SetlerDal;

        public StudentsManager(IUsersDal usersDal, IStudents_SetlerDal students_SetlerDal)
        {
            _usersDal = usersDal;
            _students_SetlerDal = students_SetlerDal;
        }

        public Students GetById(int? id)
        {
            return _usersDal.Get(x => x.StudentID == id);
        }

        public List<Students> GetList()
        {
            var values = _usersDal.List(x => x.Status == true).ToList();
            values.ForEach(x =>
            {
                x.students_Setlers = _students_SetlerDal.List();
            });
            return values;
        }

        public void StudentAdd(Students users)
        {
            users.Status = true;
            _usersDal.Insert(users);
        }

        public void StudentDelete(Students users)
        {
            users.Status = false;
            _usersDal.Update(users);
        }

        public void StudentUpdate(Students users)
        {
            _usersDal.Update(users);
        }
    }
}
