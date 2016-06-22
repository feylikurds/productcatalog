namespace Product_Catalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Information : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Information", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Information");
        }
    }
}
