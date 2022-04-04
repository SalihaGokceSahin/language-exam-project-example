using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace language_exam.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public virtual DbSet<match> Matches { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Exams> Exams { get; set; }


    }
}
