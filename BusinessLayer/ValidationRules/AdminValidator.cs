using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admins>
    {
        public AdminValidator()
        {
            RuleFor(x => x.İsim).NotEmpty().WithMessage("Admin adını boş geçemezsiniz.");
            RuleFor(x => x.Soyisim).NotEmpty().WithMessage("Admin soyadını boş geçemezsiniz.");
            RuleFor(x => x.AdminMail).NotEmpty().WithMessage("Maili boş geçemezsiniz.");
            RuleFor(x => x.AdminŞifre).NotEmpty().WithMessage("Şifreyi boş geçemezsiniz.");
            RuleFor(x => x.AdminŞifre).MinimumLength(3).WithMessage("Şifre en kısa 3 karakter olmalı.");
        }
    }
}
