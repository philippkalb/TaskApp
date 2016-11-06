using SQLite;

namespace TestApp2.model {

   public class TaskList  {

        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
