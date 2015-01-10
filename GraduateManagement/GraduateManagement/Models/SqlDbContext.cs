using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateManagement.Models
{
    public class SqlDbContext : DbContext
    {
        public DbSet<users> user_table { get; set; }
        public DbSet<notices> notice_table { get; set; }
        public DbSet<directs> direct_table { get; set; }
        public DbSet<reply> reply_table { get; set; }
        public DbSet<progress> progress_table { get; set; }
        public DbSet<authority> authority_table { get; set; }
    }
}