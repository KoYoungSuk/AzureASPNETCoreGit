using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;

namespace AzureWebApplication.Models
{
    public class manageproduct_table
    {
        [Key]
        public string product_no { get; set; }

        public string product_name { get; set; }

        public string product_type { get; set; }

        public string manufacture_date { get; set; }

        public string expired_date { get; set; }

        public int product_amount { get; set; }

        public string buy_date { get; set; }

        public int price { get; set; }
    }
    public class ManageContext : DbContext
    {
        public ManageContext() : base("MsSQLConnection") { }
        public DbSet<manageproduct_table> ManageModels { get; set; }
    }

}
