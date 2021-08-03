using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace testje_amk.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            IdentityUser user1 = new IdentityUser();
            user1.Id = Guid.NewGuid().ToString();
            user1.Email = "admin@gmail.com";
            user1.UserName = "admin";
            builder.Entity<IdentityUser>().HasData(new IdentityUser[] { user1 });
        }
    }
}
