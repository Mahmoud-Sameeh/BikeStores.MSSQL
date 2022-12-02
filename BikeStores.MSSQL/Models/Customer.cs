﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BikeStores.MSSQL.Models.IRepository;
using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Collections.Generic;

namespace BikeStores.MSSQL.Models
{
    public partial class Customer : Audit
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}