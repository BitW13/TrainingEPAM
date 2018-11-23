using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task015New.Models;

namespace Task015New.Context
{
    public class UserContext:DbContext
    {
        public UserContext() : base("UserConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}