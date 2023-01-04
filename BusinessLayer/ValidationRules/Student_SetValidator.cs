using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class Student_SetValidator : AbstractValidator<Students_Setler>
    {
        public Student_SetValidator()
        {
            RuleFor(x => x.StudentID).NotEmpty().WithMessage("Öğrenci ID Boş olmamalıdır.");
            RuleFor(x => x.SetID).NotEmpty().WithMessage("SetID Boş olmamalıdır.");
        }
    }
}
