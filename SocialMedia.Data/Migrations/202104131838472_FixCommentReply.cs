namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCommentReply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Commentid = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        Authorid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Commentid, cascadeDelete: true)
                .Index(t => t.Commentid);
            
            AddColumn("dbo.Comments", "AuthorID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Post", "PostId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "Commentid", "dbo.Comments");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "Commentid" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropColumn("dbo.Comments", "AuthorID");
            DropTable("dbo.Reply");
        }
    }
}
