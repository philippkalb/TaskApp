using SQLite;

namespace TestApp2.infrastructure
{
    public interface ISQLite {
        SQLiteConnection GetConnection();
    }
}
