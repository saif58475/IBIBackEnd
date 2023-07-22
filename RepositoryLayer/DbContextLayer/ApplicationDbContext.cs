using DomailLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DbContextLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        public DbSet<User> users { get; set; }
        public DbSet<Religion> religions { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Student> students { get; set; }
    }
}
