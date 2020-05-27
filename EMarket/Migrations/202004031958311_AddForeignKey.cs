namespace EMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "category_id1", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_id1" });
            DropColumn("dbo.Products", "category_id");
            RenameColumn(table: "dbo.Products", name: "category_id1", newName: "category_id");
            AlterColumn("dbo.Products", "category_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "category_id");
            AddForeignKey("dbo.Products", "category_id", "dbo.Categories", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "category_id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_id" });
            AlterColumn("dbo.Products", "category_id", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "category_id", newName: "category_id1");
            AddColumn("dbo.Products", "category_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "category_id1");
            AddForeignKey("dbo.Products", "category_id1", "dbo.Categories", "id");
        }
    }
}
