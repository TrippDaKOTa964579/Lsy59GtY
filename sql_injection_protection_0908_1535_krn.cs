// 代码生成时间: 2025-09-08 15:35:07
using System;
using System.Data.SqlClient;

namespace SQLInjectionPrevention
{
    public class SQLInjectionProtection
    {
        private readonly string connectionString;

        public SQLInjectionProtection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves data from a database using a parameterized query to prevent SQL injection.
        /// </summary>
        /// <param name="searchTerm">The term to search for in the database.</param>
        /// <returns>A SqlDataReader containing the query results.</returns>
        public SqlDataReader GetData(string searchTerm)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM YourTable WHERE ColumnName = @SearchTerm";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", searchTerm);
                        return command.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as required by your application
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; // Re-throw the exception for further handling
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Replace with your actual database connection string
            string connectionString = "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;";

            SQLInjectionProtection protection = new SQLInjectionProtection(connectionString);
            SqlDataReader reader = protection.GetData("example_search_term");

            // Process the data reader as needed
            while (reader.Read())
            {
                // Perform operations on each record
            }

            reader.Close();
        }
    }
}