namespace server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocUpdate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Locations");
            AddColumn("dbo.Locations", "LocationID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Locations", "Address", c => c.String());
            AddPrimaryKey("dbo.Locations", "LocationID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Locations");
            AlterColumn("dbo.Locations", "Address", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Locations", "LocationID");
            AddPrimaryKey("dbo.Locations", "Address");
        }
    }
}
