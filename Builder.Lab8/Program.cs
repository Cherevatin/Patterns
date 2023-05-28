using System.Text;

#region ClientCode

// Initialize the system
var dbFramework = new DbFramework();

// Using the query builder for PostgreSQL
var postgreSQLQuery = dbFramework.PostgreSQL.Select("column1, column2")
                                            .Where("column1 = 5")
                                            .Limit(10)
                                            .GetSQL();

// Using Query Builder for MySQL
var mySQLQuery = dbFramework.MySQL.Select("column1, column2")
                                  .Where("column1 = 5")
                                  .Limit(10)
                                  .GetSQL();

#endregion

#region ClassStructure

// System
public class DbFramework
{
    public PostgreSQLQueryBuilder PostgreSQL { get; set; } = new PostgreSQLQueryBuilder();
    public MySQLQueryBuilder MySQL { get; set; } = new MySQLQueryBuilder();
}

// Query builder interface
public interface IQueryBuilder<T>
{
    T Select(string columns);
    T Where(string condition);
    T Limit(int limit);
    string GetSQL();
}

// Implementation of query builder for PostgreSQL
public class PostgreSQLQueryBuilder : IQueryBuilder<PostgreSQLQueryBuilder>
{
    private StringBuilder query;

    public PostgreSQLQueryBuilder()
    {
        query = new StringBuilder();
    }

    public PostgreSQLQueryBuilder Select(string columns)
    {
        // Adding the SELECT part of the query for PostgreSQL
        return this;
    }

    public PostgreSQLQueryBuilder Where(string condition)
    {
        // Adding the WHERE part of the query for PostgreSQL
        return this;
    }

    public PostgreSQLQueryBuilder Limit(int limit)
    {
        // Adding the LIMIT part of the query for PostgreSQL
        return this;
    }

    public string GetSQL()
    {
        // Returning a generated SQL query for PostgreSQL
        return query.ToString();
    }
}

// Implementation of query builder for MySQL
public class MySQLQueryBuilder : IQueryBuilder<MySQLQueryBuilder>
{
    private StringBuilder query;

    public MySQLQueryBuilder()
    {
        query = new StringBuilder();
    }

    public MySQLQueryBuilder Select(string columns)
    {
        // Adding the SELECT part of the query for MySQL
        return this;
    }

    public MySQLQueryBuilder Where(string condition)
    {
        // Adding the WHERE part of the query for MySQL
        return this;
    }

    public MySQLQueryBuilder Limit(int limit)
    {
        // Adding the LIMIT part of the query for MySQL
        return this;
    }

    public string GetSQL()
    {
        // Returning a generated SQL query for MySQL
        return query.ToString();
    }
}

#endregion