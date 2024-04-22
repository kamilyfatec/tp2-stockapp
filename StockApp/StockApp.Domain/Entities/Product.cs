using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        private int id;
        #region Atributos
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        #endregion
        
        #region Construtores
        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            Id = id;
            ValidateDomain(name, description, price, stock, image, categoryId);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        public Product()
        {

        }

        public static void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainExceptionValidation(message);
        }

        public Product(int id, string name)
        {
            ValidateDomain(name);
            Id = id;
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
          
        }
        
        #endregion

        public Category Category { get; set; }

        #region Validação
        
        private void ValidateDomain(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                throw new DomainExceptionValidation("Invalid name, name is required.");
            }

            if (name.Length < 3)
            {
                throw new DomainExceptionValidation("Invalid name, too short, minimum 3 characters.");
            }

            if (name.Length > 100)
            {
                throw new DomainExceptionValidation("Invalid name, too long, maximum 100 characters.");

            }

        }
        
        private void ValidateDomain(string name, string description, decimal price, int stock, string image, int categoryId)
        {

            ValidateDomain(name);

            DomainExceptionValidation.When(id < 0, "Invalid Id value.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, description is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");
           
            
            DomainExceptionValidation.When(description.Length > 200,
            "Invalid description, too long, maximum 200 characters.");
            
            DomainExceptionValidation.When(price < 0, "Invalid price negative value.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock negative value.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image) || image.Length > 250, "Invalid image name.");

            DomainExceptionValidation.When(categoryId <= 0, "Invalid CategoryId value.");

        }
        #endregion
    }
}
   