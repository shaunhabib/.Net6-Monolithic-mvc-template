using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monolithic_mvc_temp.Models;

namespace Monolithic_mvc_temp.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {

        }

        public DbSet<Employee> Employee_tbl {get; set;}
    }
}