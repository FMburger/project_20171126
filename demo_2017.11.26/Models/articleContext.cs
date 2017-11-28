using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace demo_2017._11._26.Models
{
    public class articleContext:DbContext
    {
        public articleContext():base("test")
        {

        }
        public DbSet<article> articles { get; set; }
    }
}