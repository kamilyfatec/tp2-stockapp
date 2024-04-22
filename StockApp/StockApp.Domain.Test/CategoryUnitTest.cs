using FluentAssertions;
using Newtonsoft.Json.Linq;
using StockApp.Domain.Entities;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos 
        [Fact (DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");  
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Negativos 
        [Fact(DisplayName = "Create Category With Invalid State Id")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category With Invalid State Name")]
        public void CreateCategory_WithInvalidParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Category With Null State Name")]
        public void CreateCategory_WithNullParameters_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Category With Empty Throws Exception")]
        public void CreateCategory_WithEmptyName_ShouldTrowValidationException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Category With Maximum Length Name")]
        public void CreateCategory_WithMaximumLengthName_ShouldNotThrowException()
        {
         string longName = new string('x', 101); 
         Action action = () => new Category(1, longName);
         action.Should().NotThrow<Validation.DomainExceptionValidation>();
         }

        #endregion
    }
}