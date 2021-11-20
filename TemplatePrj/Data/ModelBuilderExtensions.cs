using Microsoft.EntityFrameworkCore;

namespace TemplatePrj.Data
{

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Department
            //modelBuilder.Entity<Department>()
            //    .HasData(
            //       new Department { DepartmentID = 1, Name = "HR" },
            //       new Department { DepartmentID = 2, Name = "Admin" },
            //       new Department { DepartmentID = 3, Name = "Development" }
            //);
        }
    }
}
