namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddisValid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "isValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHang", "isValid");
        }
    }
}
