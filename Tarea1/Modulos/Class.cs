using System.ComponentModel.DataAnnotations;
using System;

namespace Tarea1.Modulos
{
    public class Person
    {
        public Person(string name, string lastName) 
        {
            Name = name;
            LastName = lastName;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
