namespace SqlServerBulkInsert;

// https://makolyte.com/csharp-how-to-use-sqlbulkcopy-to-do-a-bulk-insert/
public class Program
{
    public static void Main()
    {
        var tableShippers = SqlManager.GenerateDataTable();

        SqlManager.BulkInsert(tableShippers);

        //SqlManager.DeleteRowsCreatedInDemo();
    }
}