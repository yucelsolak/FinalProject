using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p=>p.CategoryId==1);
            RuleFor(p => p.ProductName).Must(StartwithA).WithMessage("Ürünler A harfiyle başlamalı.");

        }

        //Ürün adı A harfi ile başlamalı gibi durumlarda kullanılır.
        private bool StartwithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
