using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    class Student_SetValidator : AbstractValidator<Students_Setler>
    {
        public Student_SetValidator()
        {
            
        }
    }
}
