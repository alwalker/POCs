﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examples.FirstProject.Entities
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual IList<Store> StoresStockedIn { get; set; }

        public Product()
        {
            StoresStockedIn = new List<Store>();
        }
    }
}
