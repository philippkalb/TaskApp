using SQLite;

namespace TestApp2.model {

   public class Task {

        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Count { get; set; }

        public long TaskListId { get; set; }
    }
}
