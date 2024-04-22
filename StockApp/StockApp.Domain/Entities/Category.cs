using Microsoft.VisualBasic;
using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StockApp.Domain.Entities
{
    public class Category
    {
        #region atributos
        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region construtores
        public Category(string name)
        {
            ValidateDomain(name);

        }


        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "invalid id value.");
            Id = id;
            ValidateDomain(name);
        }

        public Category()
        {
        }
        #endregion region


        #region validacoes
        public ICollection<Product> Products { get; set; }


        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is requered.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short minimum 3 characters.");
            Name = name;

            DomainExceptionValidation.When(name.Length > 100,
            "Invalid  name. too long, maximum 100 characters.");
        }
        #endregion 

    }
}
