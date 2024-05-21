namespace TraveliserAPI
{
    using Microsoft.Data.Sqlite;
    public class DBContext
    {
        public SqliteConnection GetConnection(string path)
        {
            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = $"Data Source={path}\\chinook.db;Cache=Shared;Foreign Keys=True;Pooling=True";

            return conn;
        }
    }
}
