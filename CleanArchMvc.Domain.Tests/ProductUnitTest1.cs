using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "Product Image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExecptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");

        }

        [Fact]
        public void CreateProduct_ShorNameValue_DomainExecptionShorName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");

        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExecptionLongImageName()
        {
            Action action = () => new Product(1, "Produto", "Product Description", 9.99m,
                99, "Product ImageProduct ImageProduct ImageProduct ImageProduct ImageProduct ImageProduct " +
                    "Product ImageProduct ImageProduct ImageProduct ImageProduct ImageProduct Image" +
                    "Product ImageProduct ImageProduct ImageProduct ImageProduct Image" +
                    "Product ImageProduct ImageProduct ImageProduct ImageProduct Image" +
                    "Product ImageProduct ImageProduct ImageImageProduct ImageProduct ImageProduct ImageProduct ImageProduct ImageProduct Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");

        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainExecption()
        {
            Action action = () => new Product(1, "Produto", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();


        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Produto", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();

        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainExecption()
        {
            Action action = () => new Product(1, "Produto", "Product Description", 9.99m, 99, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainExecption()
        {
            Action action = () => new Product(1, "Produto", "Product Description", -9.99m, 99, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }
        

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Produto", "Product Description", 9.99m, value, "Product Image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }






    }
}
