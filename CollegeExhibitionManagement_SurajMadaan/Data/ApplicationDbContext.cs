using System;
using System.Collections.Generic;
using System.Text;
using CollegeExhibitionManagement_SurajMadaan.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollegeExhibitionManagement_SurajMadaan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExhibitionCoordinator> ExhibitionCoordinators { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassMaster> ClassMasters { get; set; }
    }
}
