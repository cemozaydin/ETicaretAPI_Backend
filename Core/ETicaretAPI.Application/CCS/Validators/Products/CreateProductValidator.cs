using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CCS.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Lütfen ürün adı giriniz.");
            RuleFor(p => p.ProductName).MaximumLength(150).WithMessage("Ürün adı 150 karakterden fazla olamaz");

            RuleFor(p => p.Stock).NotNull().NotEmpty().WithMessage("Stok mitarı bilgisini boş geçmeyiniz.");
            RuleFor(p => p.Stock).GreaterThanOrEqualTo(1).WithMessage("Stok miktarını 0'dan büyük giriniz.");

            RuleFor(p => p.Price).NotNull().NotEmpty().WithMessage("Fiyat bilgisini boş geçmeyiniz");
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");
        }
    }
}
