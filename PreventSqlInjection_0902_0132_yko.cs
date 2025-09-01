// 代码生成时间: 2025-09-02 01:32:38
using System;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

// This class demonstrates how to use parameterized queries to prevent SQL injection attacks.
public class DatabaseHelper
{
    // This function connects to a database and retrieves data using a parameterized query.
    public DataTable GetDataUsingParameterizedQuery(string query, SqlParameter[] parameters)
    {
        // Initialize the DataTable to store the results.
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        {
            try
            {
                // Open the database connection.
                connection.Open();

                // Create a SqlCommand with the provided query and connection.
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters to the SqlCommand.
                    command.Parameters.AddRange(parameters);

                    // Execute the command and fill the DataTable with the results.
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions, such as connection errors or timeouts.
                Console.WriteLine("An error occurred while accessing the database: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions.
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
        return dataTable;
    }

    // This method is used to retrieve the database connection string from a secure location.
    // In a production environment, this should be stored securely and not hard-coded.
    private string GetConnectionString()
    {
        return "Your connection string here"; // Replace with your actual connection string.
    }
}

// Example usage of the DatabaseHelper class to fetch data with a parameterized query.
public class Program
{
    public static void Main()
    {
        // Create an instance of the DatabaseHelper.
        DatabaseHelper dbHelper = new DatabaseHelper();

        // Define the parameterized query.
        string query = "SELECT * FROM Users WHERE UserName = @UserName";

        // Create the SQL parameters.
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@UserName", SqlDbType.VarChar) { Value = "JohnDoe" }
        };

        // Retrieve data using the parameterized query.
        DataTable dataTable = dbHelper.GetDataUsingParameterizedQuery(query, parameters);

        // Process the data as needed.
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine("Username: " + row["UserName"].ToString());
        }
    }
}