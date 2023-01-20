using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentValidator : AbstractValidator<Students>
    {
        public StudentValidator()
        {
            RuleFor(x => x.İsim).NotEmpty().WithMessage("Öğrenci adı boş gecilemez.");
            RuleFor(x => x.Soyisim).NotEmpty().WithMessage("Öğrenci soyadı boş gecilemez.");
            RuleFor(x => x.TCKimlikNumarasi).NotEmpty().WithMessage("TC Kimlik Numarasını boş gecilemez.");
            RuleFor(x => x.OkulNumarasi).NotEmpty().WithMessage("Okul Numarası boş gecilemez.");
            RuleFor(x => x.Sinif).NotEmpty().WithMessage("Sınıf boş gecilemez.");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre boş gecilemez.");



            RuleFor(x => x.Sifre).MaximumLength(11).WithMessage("6 karakter olmalı.");
            RuleFor(x => x.Sifre).MinimumLength(11).WithMessage("6 karakter olmalı.");

            RuleFor(x => x.TCKimlikNumarasi).MaximumLength(11).WithMessage("11 karakter olmalı.");
            RuleFor(x => x.TCKimlikNumarasi).MinimumLength(11).WithMessage("11 karakter olmalı.");

        }
    }
}
