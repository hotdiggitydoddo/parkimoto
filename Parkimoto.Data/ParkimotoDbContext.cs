﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parkimoto.Core;

namespace Parkimoto.Data
{
    public class ParkimotoDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ParkimotoDbContext() : base("ParkimotoDbContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Tag>()
        //        .HasMany(t => t.Posts)
        //        .WithMany(t => t.Tags)
        //        .Map(m =>
        //        {
        //            m.ToTable("PostTags");
        //            m.MapLeftKey("PostId");
        //            m.MapRightKey("TagId");
        //        });

        //    modelBuilder.Entity<Post>()
        //    .HasMany(t => t.Comments)
        //    .Map(m =>
        //    {
        //        m.ToTable("PostTags");
        //        m.MapLeftKey("PostId");
        //        m.MapRightKey("TagId");
        //    });


        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
