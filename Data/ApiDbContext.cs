using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Data
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext(DbContextOptions <ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Affectation> Affecations { get; set; }
    }
}
