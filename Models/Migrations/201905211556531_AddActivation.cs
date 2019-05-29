namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHang", "Activation", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhachHang", "Activation");
        }
    }
}
