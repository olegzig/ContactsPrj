using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactsPrj.Models;

namespace ContactsPrj.Data
{
    public class ContactsPrjContext : DbContext
    {
        public ContactsPrjContext (DbContextOptions<ContactsPrjContext> options)
            : base(options)
        {
        }

        public DbSet<ContactsPrj.Models.Contact> Contact { get; set; }
    }
}
