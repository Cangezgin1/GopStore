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

        public StudentsManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public Students GetById(int id)
        {
            return _usersDal.Get(x=>x.StudentID == id);
        }

        public List<Students> GetList()
        {
            return _usersDal.List();
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
