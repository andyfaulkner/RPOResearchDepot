﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPOResearchDepot.Domain.Entities;
using System.Data.Entity;

namespace RPOResearchDepot.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        //create the connection to the product database using entity framework
        public DbSet<Product> Products { get; set; }
    }
}
