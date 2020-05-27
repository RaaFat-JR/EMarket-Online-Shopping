namespace EMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Product_id = c.Int(nullable: false),
                        Added_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Product_id)
                .ForeignKey("dbo.Products", t => t.Product_id)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Product_id", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_id" });
            DropTable("dbo.Carts");
        }
    }
}
