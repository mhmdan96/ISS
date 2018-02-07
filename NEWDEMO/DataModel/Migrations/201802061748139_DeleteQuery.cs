namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteQuery : DbMigration
    {
        public override void Up() => Sql(@"CREATE PROCEDURE [dbo].[DeleteOperation]
AS

    DELETE From operations where vendorName = 'ahmad'
RETURN 0
");

        public override void Down()
        {
        }
    }
}
