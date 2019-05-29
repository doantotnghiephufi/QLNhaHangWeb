namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatMonTruoc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhieuDatBan", "DatMonTruoc", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhieuDatBan", "DatMonTruoc");
        }
    }
}
