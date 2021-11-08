using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TemplatePrj.Models;

namespace TemplatePrj.Data
{
    public class TemplatePrjContext : IdentityDbContext
    {
        public TemplatePrjContext (DbContextOptions<TemplatePrjContext> options)
            : base(options)
        {
        }

        public DbSet<TemplatePrj.Models.Post> Post { get; set; }
    }
}
