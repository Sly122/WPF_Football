using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Resources;
using WPF_Football.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WPF_Football.Database
{
    internal class DatabaseConnection : DbContext
    {
        public string connection = null;
        public DatabaseConnection()
        {
            connection = ConfigurationManager.AppSettings.Get("DBurl");
        }

        public DbSet<Teams> Teams { get; set; }
        public DbSet<Fixtures> Fixtures { get; set; }
        public DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connection);
        }
    }
}
