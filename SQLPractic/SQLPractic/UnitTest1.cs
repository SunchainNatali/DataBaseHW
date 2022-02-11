using System;
using Xunit;
using System.Data.SQLite;

namespace SQLPractic
{
    public class UnitTest1
    {

        [Fact]
        public void Check_Model_Car()
        {
            SQLiteConnection database = SQLHelper.Connection(@"Data Source=/Users/natalanikulina/Desktop/NataliNatalya.db");

            SQLiteCommand command = SQLHelper.SQLCommand(database, "SELECT model FROM brand WHERE brand_id = " +
            "(SELECT brand_id FROM list_cars WHERE transmission = 'AT' AND country_id = 1) ");

            string facts = (string)command.ExecuteScalar();

            Assert.Equal("GRAND_CHEROKEE", facts);

            SQLHelper.CloseSQLConnection(database);
        }
                  
        [Fact]
        public void Check_Country_BrandName()
        {
            SQLiteConnection database = SQLHelper.Connection(@"Data Source=/Users/natalanikulina/Desktop/NataliNatalya.db");

            SQLiteCommand command = SQLHelper.SQLCommand(database, "SELECT country_name FROM country WHERE country_id = " +
            "(SELECT country_id FROM list_cars WHERE brand_name= 'BMW' AND body_type = 'Sedan') ");

            string facts = (string)command.ExecuteScalar();

            Assert.Equal("Germany", facts);

            SQLHelper.CloseSQLConnection(database);
        }

        [Fact]
        public void Check_Price_BrandCar()
        {
            SQLiteConnection database = SQLHelper.Connection(@"Data Source=/Users/natalanikulina/Desktop/NataliNatalya.db");

            SQLiteCommand command = SQLHelper.SQLCommand(database, "SELECT price FROM brand WHERE brand_id = " +
            "(SELECT brand_id FROM list_cars WHERE country_id = '2' AND transmission = 'AT') ");

            string facts = (string)command.ExecuteScalar();

            Assert.Equal("15.000$", facts);

            SQLHelper.CloseSQLConnection(database);
        }

        [Fact]
        public void Check_Made_Year_BrandCar()
        {
            SQLiteConnection database = SQLHelper.Connection(@"Data Source=/Users/natalanikulina/Desktop/NataliNatalya.db");

            SQLiteCommand command = SQLHelper.SQLCommand(database, "SELECT made_year FROM brand WHERE brand_id = " +
            "(SELECT brand_id FROM list_cars WHERE brand_name = 'OPEL' AND transmission = 'AT') ");

            var facts = command.ExecuteScalar();

            Assert.Equal(2003, Convert.ToInt32(facts));

            SQLHelper.CloseSQLConnection(database);
        }
    }
}
