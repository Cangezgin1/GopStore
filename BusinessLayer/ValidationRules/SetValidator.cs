using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SetValidator : AbstractValidator<Setler>
    {
        public SetValidator()
        {
            RuleFor(x => x.SetAdi).NotEmpty().WithMessage("Set adını boş geçemezsiniz.");
            RuleFor(x => x.SetBilgisi).NotEmpty().WithMessage("Set bilgisini boş geçemezsiniz.");
            RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Set fiyatını boş geçemezsiniz.");
        }

    }
}
