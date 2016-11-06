using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using TestApp2.infrastructure;


[assembly: Dependency(typeof(SQLite_WinPhone))]

public class SQLite_WinPhone : ISQLite
{
    public SQLite_WinPhone() { }
    public SQLite.SQLiteConnection GetConnection()
    {
        var sqliteFilename = "TodoSQLite.db3";
        string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        // Create the connection
        var conn = new SQLite.SQLiteConnection(path);
        // Return the database connection
        return conn;
    }
}