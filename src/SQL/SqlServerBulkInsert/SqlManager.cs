using System.Data;
using System.Data.SqlClient;

namespace SqlServerBulkInsert;

public static class SqlManager
{
    private const string ConnectionString = "Server=localhost;Database=Northwind;Integrated Security=True;";

    public static DataTable GenerateDataTable()
    {
        var random = new Random();
        string[] names = new string[] { "ABBA", "Beatles", "DMX", "Eminem", "Louis Armstrong", "Metallica", "Run The Jewels", "Snoop Dogg", "Venom", "ZZ Top" };

        var tableShippers = new DataTable { TableName = "Shippers" };

        tableShippers.Columns.Add("ShipperID", typeof(int));
        tableShippers.Columns.Add("ShipperName", typeof(string));
        tableShippers.Columns.Add("Phone", typeof(string));

        // i = 4 because Northwind comes with 3 seeded rows in Shippers
        for (int i = 4; i < 101; i++)
        {
            var row = tableShippers.NewRow();
            row["ShipperID"] = i;
            row["ShipperName"] = names[random.Next(0, names.Length)];
            row["Phone"] = "+35989" + random.Next(2, 10) + random.Next(1, 1000000).ToString("D6");
            tableShippers.Rows.Add(row);
        }

        return tableShippers;
    }

    public static void BulkInsert(DataTable table)
    {
        using (var bulkInsert = new SqlBulkCopy(ConnectionString))
        {
            bulkInsert.DestinationTableName = table.TableName;
            bulkInsert.WriteToServer(table);
        }
    }

    public static void DeleteRowsCreatedInDemo()
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            var commandDelete = new SqlCommand(
                @"DELETE FROM[Northwind].[dbo].[Shippers] WHERE Phone LIKE '+359%'",
                connection);

            Console.WriteLine(commandDelete.ExecuteNonQuery() + " rows affected.");
        }
    }
}
