using StockApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Product
    {

        #region atributos
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string image { get; set; }

        public int CategoryId { get; set; }

      
        #endregion

        public Product()
        {

        }
        public Category Category { get; set; }

        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short minimum 3 characters.");
           

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
               "Invalid name, name is requered.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
               "Invalid description, description is requered.");

            DomainExceptionValidation.When(description.Length < 5, 
                "Invalid descripton, too short minimum e characters.");
           

        }

    }




}
