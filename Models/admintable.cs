using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;

namespace AzureWebApplication.Models
{
    public class admintable
    {
        [Key]
        public string Id { get; set; }
        public string password { get; set; }        
    }
}
