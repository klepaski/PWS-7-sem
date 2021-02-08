﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PWS_3.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [StringLength(30, ErrorMessage = "Name length must be less 30 symbols")]
        public string Name { get; set; }
        
        [StringLength(30, ErrorMessage = "Phone lenght must be less 30 symbols")]
        public string Phone { get; set; }
    }
}