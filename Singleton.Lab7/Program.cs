

var mongodb = OS.GetMongoDBConnection();
var postgres = OS.GetPostgreSQLConnection();

if (mongodb == OS.GetMongoDBConnection())
{
    Console.WriteLine("Same instances.");
}

if (postgres == OS.GetPostgreSQLConnection())
{
    Console.WriteLine("Same instances.");
}

public class PostgreSQL
{
    public void Connect()
    {
        Console.WriteLine("Trying to connect PostgreSQL");
    }
}

public class MongoDB
{
    public void Connect()
    {
        Console.WriteLine("Trying to connect MongoDB");
    }
}

public class OS
{
    private static MongoDB MongoDB;
    private static PostgreSQL PostgreSQL;

    public OS()
    { }

    public static MongoDB GetMongoDBConnection()
    {
        if (MongoDB == null)
        {
            MongoDB = new MongoDB();
            MongoDB.Connect();
        }
        return MongoDB;
    }

    public static PostgreSQL GetPostgreSQLConnection()
    {
        if (PostgreSQL == null)
        {
            PostgreSQL = new PostgreSQL();
            PostgreSQL.Connect();
        }
        return PostgreSQL;
    }
}