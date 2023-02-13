using System;
namespace moment2.Models
{
    public class Dogs {
         public Dogs(string name, string breed, int age)
        {
            Name = name;
            Breed = breed;
            Age = age;
        }
        public int Id { get; set;}
        public String? Name { get; set;}
        public String? Breed { get; set; }

        public int Age { get; set;}        
    }
}