using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using TestApp2.infrastructure;


// ...
[assembly: Dependency(typeof(SQLite_UWP))]
// ...
public class SQLite_UWP : ISQLite {
    public SQLite_UWP() { }
    public SQLite.SQLiteConnection GetConnection() {
        var sqliteFilename = "TodoSQLite.db3";
        string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        var conn = new SQLite.SQLiteConnection(path);
        return conn;
    }
}
