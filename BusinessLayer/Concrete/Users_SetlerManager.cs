﻿using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Users_SetlerManager : IStudents_SetlerService
    {
        IStudents_SetlerDal _users_SetlerDal;

        public Users_SetlerManager(IStudents_SetlerDal users_SetlerDal)
        {
            _users_SetlerDal = users_SetlerDal;
        }

        public Students_Setler GetById(int id)   // DEĞİŞTİRİLEBİLİR.....
        {
            return _users_SetlerDal.Get(x=>x.StudentID == id);
        }

        public List<Students_Setler> GetList()
        {
            return _users_SetlerDal.List();
        }

        public void WriterAdd(Students_Setler users_Setler)
        {
            _users_SetlerDal.Insert(users_Setler);
        }

        public void WriterDelete(Students_Setler users_Setler)
        {
            _users_SetlerDal.Delete(users_Setler);
        }

        public void WriterUpdate(Students_Setler users_Setler)
        {
            _users_SetlerDal.Update(users_Setler);
        }
    }
}
