namespace EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnBookPageCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.article", "nombre_page", c => c.Int());
            Sql("UPDATE article SET nombre_page = 10");
        }
        
        public override void Down()
        {
            DropColumn("dbo.article", "nombre_page");
        }
    }
}
