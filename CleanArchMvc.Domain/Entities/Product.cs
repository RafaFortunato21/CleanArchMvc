using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }


        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidadeDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.when(id < 0, "Invalid Id value.");
            Id = id;
            ValidadeDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidadeDomain(name, description, price, stock, image);
            CategoryId = CategoryId;
        }

        private void ValidadeDomain(string name, string description, decimal price, int stock, string image) {

            DomainExceptionValidation.when(string.IsNullOrEmpty(name),
                    "Invalid name. Name is required");

            DomainExceptionValidation.when(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.when(string.IsNullOrEmpty(description),
                    "Invalid description. Description is required");

            DomainExceptionValidation.when(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.when(price < 0, 
                "Invalid price value.");

            DomainExceptionValidation.when(stock < 0,
                "Invalid stock value.");

            DomainExceptionValidation.when(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
