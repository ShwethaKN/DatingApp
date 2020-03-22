using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DatingApp.Api.Model;

namespace DatingApp.Api.Data
{
    public class DatingAppDbContext : DbContext
    {
        public DbSet<TestModel> TestModels {get;set;}

        public DatingAppDbContext(DbContextOptions<DatingAppDbContext> options) : base(options)
        {
        }

        protected DatingAppDbContext()
        {
        }
    }
}