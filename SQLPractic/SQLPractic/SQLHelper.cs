using System;
using System.Collections.Generic;
using System.Data.SQLite;
namespace SQLPractic
{
    public class SQLHelper
    {      
            public static SQLiteConnection Connection(string dataBasePath)

            {
                string StringConnect = dataBasePath;

                SQLiteConnection database = new SQLiteConnection(StringConnect);

                database.Open();

                return database;
            }

            public static SQLiteCommand SQLCommand(SQLiteConnection database, string request)

            {
                SQLiteCommand command = database.CreateCommand();

                command.CommandText = request;

                return command;
            }

            public static void CloseSQLConnection(SQLiteConnection database)

            {
                database.Close();
            }

        


    }
}
