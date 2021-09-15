namespace aspapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingBirthdayForCustomers : DbMigration
    {
        public override void Up()
        {
            Sql($"UPDATE Customers SET Birthdate = '{DateTime.Now.ToString("M/d/yyyy")}' WHERE Id IN (2, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
