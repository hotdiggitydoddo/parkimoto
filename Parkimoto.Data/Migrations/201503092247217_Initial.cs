namespace Parkimoto.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "public.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Content = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        ParentComment_Id = c.Int(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Comments", t => t.ParentComment_Id)
                .ForeignKey("public.Posts", t => t.Post_Id)
                .Index(t => t.ParentComment_Id)
                .Index(t => t.Post_Id);
            
            CreateTable(
                "public.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("public.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("public.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.TagPosts", "Post_Id", "public.Posts");
            DropForeignKey("public.TagPosts", "Tag_Id", "public.Tags");
            DropForeignKey("public.Comments", "Post_Id", "public.Posts");
            DropForeignKey("public.Comments", "ParentComment_Id", "public.Comments");
            DropForeignKey("public.Posts", "Category_Id", "public.Categories");
            DropIndex("public.TagPosts", new[] { "Post_Id" });
            DropIndex("public.TagPosts", new[] { "Tag_Id" });
            DropIndex("public.Comments", new[] { "Post_Id" });
            DropIndex("public.Comments", new[] { "ParentComment_Id" });
            DropIndex("public.Posts", new[] { "Category_Id" });
            DropTable("public.TagPosts");
            DropTable("public.Tags");
            DropTable("public.Comments");
            DropTable("public.Posts");
            DropTable("public.Categories");
        }
    }
}
