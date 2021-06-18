using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzureWebApplication.Models;

namespace AzureWebApplication.Data
{
    public class ManageContext : DbContext
    {
        public ManageContext (DbContextOptions<ManageContext> options)
            : base(options)
        {

        }

        public DbSet<AzureWebApplication.Models.manageproduct_table> manageproduct_table { get; set; }
    }
}
