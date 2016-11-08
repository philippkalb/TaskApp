using System;
using System.Collections.ObjectModel;
using System.Linq;
using TestApp2.infrastructure;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class Startpage: ContentPage {

        private ObservableCollection<model.TaskList> ListOfTasks = new ObservableCollection<model.TaskList>();

        public Startpage() {
            InitializeComponent();
            
            ListOfTasksView.ItemsSource = ListOfTasks;
            var database = DependencyService.Get<ISQLite>().GetConnection();
            var items = database.Table<model.TaskList>().Where(x => x.Id > 0);

            foreach (var list  in items) {
                ListOfTasks.Add(list);
            }
                
        }

        public async void addNewList(object sender, EventArgs e) {
            var createListController = new CreateTaskListView(ListOfTasks);
            await Navigation.PushModalAsync(createListController, true);
        }
        

        public async void ItemClicked(object sender, ItemTappedEventArgs e) {
            var item = (model.TaskList)e.Item;

            await Navigation.PushAsync(new TaskListView(item));
        }

        public void OnDelete(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            var id = (mi.BindingContext as model.TaskList).Id;

            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.Delete<model.TaskList > (id);
            var tasks = database.Table<model.Task>().Where(x => x.TaskListId == id);

            foreach(var task in tasks) {
                database.Delete(task);
            }
            
            ListOfTasks.Remove(ListOfTasks.FirstOrDefault(X => X.Id == id));
        }

        public void OnClear(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            var id = (mi.BindingContext as model.TaskList).Id;
            var database = DependencyService.Get<ISQLite>().GetConnection();
            var tasks = database.Table<model.Task>().Where(x => x.TaskListId == id);

            foreach (var task in tasks) {
                database.Delete(task);
            }
        }
    }

}
