namespace CodeFirstColor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ColorTbl",
                c => new
                    {
                        ColorId = c.Long(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.ProductColorTbl",
                c => new
                    {
                        ProductColorId = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        ColorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ProductColorId)
                .ForeignKey("dbo.ColorTbl", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.ProductTbl", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.ProductTbl",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                        MfgName = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductColorTbl", "ProductId", "dbo.ProductTbl");
            DropForeignKey("dbo.ProductColorTbl", "ColorId", "dbo.ColorTbl");
            DropIndex("dbo.ProductColorTbl", new[] { "ColorId" });
            DropIndex("dbo.ProductColorTbl", new[] { "ProductId" });
            DropTable("dbo.ProductTbl");
            DropTable("dbo.ProductColorTbl");
            DropTable("dbo.ColorTbl");
        }
    }
}
