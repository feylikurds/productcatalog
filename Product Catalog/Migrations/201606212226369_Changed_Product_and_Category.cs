namespace Product_Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_Product_and_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Name", c => c.String());
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Categories", "CategoryName");
            DropColumn("dbo.Products", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductName", c => c.String());
            AddColumn("dbo.Categories", "CategoryName", c => c.String());
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Categories", "Name");
        }
    }
}
