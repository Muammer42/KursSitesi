﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entites
{
    public class InformationAdress
    {
        [Key]
        public int InformationAddressID { get; set; }
        public string Title1 { get; set; }
        public string Address { get; set; }
        public string Title2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}