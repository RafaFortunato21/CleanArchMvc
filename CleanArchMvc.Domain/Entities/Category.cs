using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
 
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.when(id < 0, "Invalid Id value.");
            Id = id; 
            ValidateDomain(name); 
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Produtcts{ get; set; }

        private void ValidateDomain(string name) {
            DomainExceptionValidation.when(string.IsNullOrEmpty(name),
                "Invalid name, Name is required.");
            
            DomainExceptionValidation.when(name.Length < 3, 
                "Invalid name, too short, minimum 3 characters.");

            Name = name;
        
        }
    }
}
