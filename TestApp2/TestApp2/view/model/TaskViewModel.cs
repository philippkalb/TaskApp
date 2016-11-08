
namespace TestApp2.view.model {

    public class TaskViewModel {

        public TaskViewModel() {
            statusImage = "Unchecked.png";
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Count { get; set; }

        public long TaskListId { get; set; }

        public string statusImage { get; set; }

    }
}
