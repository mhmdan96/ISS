namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class project : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.operations", t => t.op_Id, cascadeDelete: true)
                .Index(t => t.op_Id);
            
            CreateTable(
                "dbo.operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        vendorName = c.String(),
                        invoiceNB = c.Int(nullable: false),
                        siteNB = c.Int(nullable: false),
                        scanDate = c.DateTime(nullable: false),
                        paymentDueDate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        voucherNB = c.Int(nullable: false),
                        bankNB = c.Int(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.invoicesviewmodels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DateModified = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        op_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.operations", t => t.op_Id, cascadeDelete: true)
                .Index(t => t.op_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invoicesviewmodels", "op_Id", "dbo.operations");
            DropForeignKey("dbo.invoiceinputs", "op_Id", "dbo.operations");
            DropIndex("dbo.invoicesviewmodels", new[] { "op_Id" });
            DropIndex("dbo.invoiceinputs", new[] { "op_Id" });
            DropTable("dbo.invoicesviewmodels");
            DropTable("dbo.operations");
            DropTable("dbo.invoiceinputs");
        }
    }
}
