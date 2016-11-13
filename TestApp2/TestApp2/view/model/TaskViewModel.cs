
using System.ComponentModel;

namespace TestApp2.view.model {

    public class TaskViewModel: INotifyPropertyChanged {

        public TaskViewModel() {
            statusImage = "Unchecked.png";
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string Count { get; set; }

        public long TaskListId { get; set; }

        private string _statusImage;

        public string statusImage {
            get {
                return _statusImage;
            }
            set {
                _statusImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("statusImage"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
