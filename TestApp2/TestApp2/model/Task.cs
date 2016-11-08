using SQLite;

namespace TestApp2.model {

   public class Task {

        public Task() {
            Fulfilled = false;
        }

        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Count { get; set; }

        public long TaskListId { get; set; }

        public bool Fulfilled { get; set; }
    }
}
