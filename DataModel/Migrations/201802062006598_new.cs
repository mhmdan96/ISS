namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.invoicesviewmodels", "op_Id", "dbo.operations");
            DropIndex("dbo.invoicesviewmodels", new[] { "op_Id" });
            DropTable("dbo.invoicesviewmodels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.invoicesviewmodels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        op_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.invoicesviewmodels", "op_Id");
            AddForeignKey("dbo.invoicesviewmodels", "op_Id", "dbo.operations", "Id", cascadeDelete: true);
        }
    }
}
