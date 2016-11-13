using System.ComponentModel;

namespace TestApp2.model {

   public class TaskListViewModel : INotifyPropertyChanged {

        public long Id { get; set; }

        public string Name { get; set; }

        private string _openItems { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;

        protected TaskListViewModel() {
        }

        public TaskListViewModel(long id, string name, int openItems) {
            Id = id;
            Name = name;
            OpenItems = string.Format("{0} open items", openItems);
        }
        
        public string OpenItems {
            get {
                return _openItems;
            }
            set {
                _openItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OpenItems"));
            }
        }

        
    }
}
