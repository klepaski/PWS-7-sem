using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        [NotMapped]
        public Link[] Links { get; set; }
        [NotMapped]
        public Status Status { get; set; }

        public Student ()
        {
            Id = 0;
            Name = null;
            Number = 0;
        }

        public Student (int id, string name, int number)
        {
            Id = id;
            Name = name;
            Number = number;
        }
    }
}