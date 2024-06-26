using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;

namespace WeatherApi.Services
{
    /// <summary>
    /// Represents a service that performs unsafe operations.
    /// </summary>
    public class UnSafeService
    {
        // Assuming "safeDirectory" is the directory you allow access to
        private readonly string safeDirectory = "path/to/safe/directory";

        /// <summary>
        /// Reads a file from the safe directory.
        /// </summary>
        /// <param name="userInput">The user input representing the file name.</param>
        /// <returns>The content of the file as a string.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown when access to the path is denied.</exception>
        public string ReadFile(string userInput)
        {
            // Validate the userInput to prevent path traversal
            var fullPath = Path.GetFullPath(Path.Combine(safeDirectory, userInput));
            if (!fullPath.StartsWith(safeDirectory))
            {
                throw new UnauthorizedAccessException("Access to the path is denied.");
            }

            using (FileStream fs = File.Open(fullPath, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    return temp.GetString(b);
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the product ID for the specified product name.
        /// </summary>
        /// <param name="productName">The name of the product.</param>
        /// <returns>The product ID as an integer.</returns>
        public int GetProduct(string productName)
        {
            using (SqlConnection connection = new SqlConnection("fakeconnectionstring"))
            {
                // Use parameterized query to prevent SQL injection
                SqlCommand sqlCommand = new SqlCommand()
                {
                    CommandText = "SELECT ProductId FROM Products WHERE ProductName = @ProductName",
                    CommandType = CommandType.Text,
                    Connection = connection
                };
                sqlCommand.Parameters.AddWithValue("@ProductName", productName);

                connection.Open();
                var result = sqlCommand.ExecuteScalar();
                connection.Close();

                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}