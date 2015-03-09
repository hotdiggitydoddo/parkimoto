using Parkimoto.Core;

namespace Parkimoto.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Parkimoto.Data.ParkimotoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ParkimotoDbContext context)
        {
            context.Posts.AddOrUpdate(
                p => p.Title,
                new Post
                {
                    Title = "Test Post",
                    Content = "This is a test post.",
                    PublishDate = DateTime.UtcNow,
                    Category = new Category
                    {
                        Name = "Testing"
                    }
                }
                );
        }
    }
}
