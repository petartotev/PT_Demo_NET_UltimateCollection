using System;
using System.Data;
using System.Data.SqlClient;

// https://makolyte.com/csharp-how-to-use-sqlbulkcopy-to-do-a-bulk-insert/

namespace Personal.SQL.BulkInsert
{
    public class Program
    {
        public static void Main()
        {
            Random rndm = new Random();
            string[] names = new string[] { "Michael Jordan", "George Michael", "McDonalds", "Mamma Leone" };

            DataTable tableShippers = new DataTable
            {
                TableName = "Shippers"
            };

            tableShippers.Columns.Add("ShipperID", typeof(int));
            tableShippers.Columns.Add("ShipperName", typeof(string));
            tableShippers.Columns.Add("Phone", typeof(string));

            for (int i = 4; i < 1001; i++)
            {
                var row = tableShippers.NewRow();
                row["ShipperID"] = i;
                row["ShipperName"] = names[rndm.Next(0, names.Length)];
                row["Phone"] = "+359 0898 12" + i.ToString("D4");
                tableShippers.Rows.Add(row);
            }

            BulkInsert(tableShippers);

            // DeleteRowsCreatedHere();
        }

        private static void BulkInsert(DataTable table)
        {
            using (var bulkInsert = new SqlBulkCopy(GetConnectionString()))
            {
                bulkInsert.DestinationTableName = table.TableName;
                bulkInsert.WriteToServer(table);
            }
        }

        private static void DeleteRowsCreatedHere()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                SqlCommand commandDelete = new SqlCommand(
                    @"DELETE
                    FROM[Northwind].[dbo].[Shippers]
                    WHERE Phone LIKE '+359%'",
                    connection);

                Console.WriteLine(commandDelete.ExecuteNonQuery() + " rows affected.");
            }
        }

        private static string GetConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Database=Northwind;Integrated Security=True;";
        }
    }
}
