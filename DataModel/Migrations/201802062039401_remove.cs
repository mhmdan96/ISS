namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.invoiceinputs", "op_Id", "dbo.operations");
            DropIndex("dbo.invoiceinputs", new[] { "op_Id" });
            DropTable("dbo.invoiceinputs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.invoiceinputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fromdate = c.DateTime(nullable: false),
                        todate = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        op_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.invoiceinputs", "op_Id");
            AddForeignKey("dbo.invoiceinputs", "op_Id", "dbo.operations", "Id", cascadeDelete: true);
        }
    }
}
