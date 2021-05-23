using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Present> Presents { get;set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    [Table("Presents", Schema ="PR")]
    public class Present
    {
        [Key]
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public String UserId { get; set; }
    }
}
