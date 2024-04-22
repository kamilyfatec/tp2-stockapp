using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        public string longImage { get; private set; }
        public string longName { get; private set; }

        public string longDesc { get; private set; }

        #region Testes Positivos 
        [Fact(DisplayName = "Create Product With All Valid Parameters")]
        public void createProduct_WithValidParameters_ShouldNotTrowValidationException()
        {
            Action action = () => new Product(1, "Valid Product Name", "Valid description", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Boundary Length Name")]
        public void createProduct_WithBoundaryLengthName_ShouldNotTrowValidationException()
        {
            Action action = () => new Product(1, "Abc", "Valid description", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Boundary Length Description")]
        public void createProduct_WithBoundaryLengthDescription_ShouldNotTrowValidationException()
        {
            Action action = () => new Product(1, "Abc", "descr", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Valid Description")]
        public void createProduct_WithValidDescription_ShouldNotTrowValidationException()
        {
            Action action = () => new Product(1, "Abc", "descr", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Zero Stock")]
        public void createProduct_WithZeroStock_ShouldNotTrowValidationException()
        {
            Action action = () => new Product(1, "Abc", "descr", 10.55m, 0, "valid_imagem.png", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Zero Price")]
        public void createProduct_WithZeroPrice_ShouldNotTrowValidationException()
        {
            Action action = () => new Product(1, "Abc", "descr", 0m, 100, "valid_imagem.png", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion
        #region Negativo

        [Fact(DisplayName = "Create Product With Null Name Exception")]
        public void createProduct_WithNullName_ShouldTrowValidationException()
        {
            Action action = () => new Product(1, null, "descr", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Empty Name Throws Exception")]
        public void createProduct_WithEmptyName_ShouldTrowValidationException()
        {
            Action action = () => new Product(1, "", "descr", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Short Name Exception")]
        public void createProduct_WithShortName_ShouldTrowValidationException()
        {
          
            Action action = () => new Product(1, "Pr", "descr", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Long Name Exception")]

        public void createProduct_WithLongName_ShouldTrowValidationException()
        
        {
            string longName = new string('x', 101);
            Action action = () => new Product(1, longName, "descr", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too long, maximum 100 characters.");
        }
        
        [Fact(DisplayName = "Create Product With Null Description Exception")]
        public void createProduct_WithNullDescription_ShouldTrowValidationException()
        {
            Action action = () => new Product(1, "Pro", null, 10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Empty Description Exception")]
        public void createProduct_WithEmptyDescription_ShouldTrowValidationException()
        {
            Action action = () => new Product(1, "Pro", "", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Short Description Exception")]
        public void createProduct_WithShortDescription_ShouldTrowValidationException()
        {
            Action action = () => new Product(1, "Pro", "desc", 10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }
     
        [Fact(DisplayName = "Create Product With Long Description Exception")]

         public void createProduct_WithLongDescription_ShouldTrowValidationException()

        {
         string longDesc = new string('x', 201);
         Action action = () => new Product(1, "Pro", longDesc, 10.55m, 100, "valid_imagem.png", 1);
         action.Should().Throw<DomainExceptionValidation>()
             .WithMessage("Invalid description, too long, maximum 200 characters.");
        }

        [Fact(DisplayName = "Create Product With Negative Price Throws Exception")]
        public void createProduct_WithNegativePrice_ShouldTrowValidationException()
        {
            Action action = () => new Product(1, "Pro", "descr", -10.55m, 100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Negative Stock Throws Exception")]
        public void createProduct_WithNegativeStock_ShouldTrowValidationException()
        {
            Action action = () => new Product(1, "Pro", "descr", 10.55m, -100, "valid_imagem.png", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Long Image Exception")]

        public void createProduct_WithLongImage_ShouldTrowValidationException()

        {
            string longImage = new string('x', 251);
            Action action = () => new Product(1, "Pro", "descr", 10.55m, 100, longImage, 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name.");
        }


        [Fact(DisplayName = "Create Product With Null Image Exception")]

        public void createProduct_WithNullImage_ShouldTrowValidationException()

        {
            string longImage = new string('x', 251);
            Action action = () => new Product(1, "Pro", "descr", 10.55m, 100, null, 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name.");
        }

        [Fact(DisplayName = "Create Product With Invalid CategoryId Throws Exception")]

        public void createProduct_WithInvalidCategoryId_ShouldTrowValidationException()

        {
            Action action = () => new Product(1, "Pro", "descr", 10.55m, 100, "valid_imagem.png", 0);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid CategoryId value.");
        }
    }
}
        #endregion
