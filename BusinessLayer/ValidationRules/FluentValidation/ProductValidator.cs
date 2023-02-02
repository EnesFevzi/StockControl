using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator() 
        { 
            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş Olamaz");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori ID Boş Olamaz"); 
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Fiyat Boş Olamaz");
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);

            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);


            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün Adı A ile Başlamalı");



        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
