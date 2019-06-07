using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FronEndClassicDev.Models;

namespace FronEndClassicDev.App_Code
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}