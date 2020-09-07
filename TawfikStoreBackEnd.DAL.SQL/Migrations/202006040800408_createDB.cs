namespace TawfikStoreBackEnd.DAL.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        _id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        userId = c.Int(nullable: false),
                        address = c.String(),
                        phone = c.String(),
                        creationDate = c.DateTime(nullable: false),
                        isDeliverd = c.Boolean(nullable: false),
                        totalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t._id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        orderId = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        Order__id = c.Int(),
                    })
                .PrimaryKey(t => new { t.orderId, t.productId })
                .ForeignKey("dbo.Orders", t => t.Order__id)
                .Index(t => t.Order__id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        image = c.String(),
                        AvilableInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(maxLength: 50),
                        lastName = c.String(maxLength: 50),
                        email = c.String(nullable: false),
                        password = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "userId", "dbo.Users");
            DropForeignKey("dbo.OrderDetails", "Order__id", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Order__id" });
            DropIndex("dbo.Orders", new[] { "userId" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
    }
}
