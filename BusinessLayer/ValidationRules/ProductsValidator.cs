using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductsValidator : AbstractValidator<Products>
    {
        public ProductsValidator()
        {
            RuleFor(x => x.ÜrünAdı).NotEmpty().WithMessage("Ürün adını boş geçemezsiniz.");
            RuleFor(x => x.ÜrünBilgisi).NotEmpty().WithMessage("Ürün bilgisini boş geçemezsiniz.");
            RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyatı boş geçemezsiniz.");
        }
    }
}
