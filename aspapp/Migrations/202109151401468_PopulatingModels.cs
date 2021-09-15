namespace aspapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingModels : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, 'Basic')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (2, 30, 1, 10, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (3, 90, 3, 15, 'Quarterly')");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (4, 300, 12, 20, 'Yearly')");

            var defaultDate = "01.01.1900 0:00:00";
            
            Sql($"INSERT INTO Movies (Name, ReleaseDate, DateAdded) VALUES ('Titanic', '{defaultDate}', '{defaultDate}')");
            Sql($"INSERT INTO Movies (Name, ReleaseDate, DateAdded) VALUES ('Terminator', '{defaultDate}', '{defaultDate}')");
            Sql($"INSERT INTO Movies (Name, ReleaseDate, DateAdded) VALUES ('Toy Story', '{defaultDate}', '{defaultDate}')");
            Sql($"INSERT INTO Movies (Name, ReleaseDate, DateAdded) VALUES ('JurassicPark', '{defaultDate}', '{defaultDate}')");
            Sql($"INSERT INTO Movies (Name, ReleaseDate, DateAdded) VALUES ('Alien', '{defaultDate}', '{defaultDate}')");

            Sql($"INSERT INTO Genres (Name) VALUES ('Romantic')");
            Sql($"INSERT INTO Genres (Name) VALUES ('Horror')");
            Sql($"INSERT INTO Genres (Name) VALUES ('Action')");
            Sql($"INSERT INTO Genres (Name) VALUES ('Comedy')");
            
        }
        
        public override void Down()
        {
        }
    }
}
