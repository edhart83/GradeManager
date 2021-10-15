using Microsoft.EntityFrameworkCore;
using System;
using GradeManager;
using GradeManager.Core;

namespace GradeManager.DAL
{
    public class GradeManagerDbContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public GradeManagerDbContext() : base()
        {

        }

        public GradeManagerDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
