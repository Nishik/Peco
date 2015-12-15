using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model.Pego;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AccessDataLayer.Pego.DataContext
{
  public class PegoDB:DbContext
    {
        public  PegoDB(): base("DefaultConnection")
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<EmailType> EmailType { get; set; }
        public DbSet<GeoLocation> GeoLocation { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemVote> ItemVote { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<PhoneType> PhoneType { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectCategory> ProjectCategory { get; set; }
        public DbSet<ProjectRole> ProjectRole { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
        public DbSet<SysRole> SysRole { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<VoteType> VoteType { get; set; }

//ПРОВЕРИТЬ!!!  http://stackoverflow.com/questions/19460386/how-can-i-change-the-table-names-when-using-visual-studio-2013-aspnet-identity/19577814#19577814
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            /* modelBuilder.Entity<IdentityRole>().ToTable("Role");
        modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
        modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
        modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");*/

            //modelBuilder.Entity<Content>()
            //    .HasMany(c => c.Editors)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Content>()
            //    .HasRequired(c => c.Owner)
            //    .WithOptional()
            //    .WillCascadeOnDelete(false);

            // modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        }
    }
}
