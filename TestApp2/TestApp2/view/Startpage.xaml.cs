using System;
using System.Collections.ObjectModel;
using System.Linq;
using TestApp2.infrastructure;
using TestApp2.model;
using TestApp2.view.model;
using Xamarin.Forms;

namespace TestApp2
{
    public partial class Startpage: ContentPage {

        private ObservableCollection<TaskListViewModel> ListOfTasks = new ObservableCollection<TaskListViewModel>();

        public Startpage() {
            InitializeComponent();
            
            ListOfTasksView.ItemsSource = ListOfTasks;
            loadTasksLists();
            MessagingCenter.Subscribe<TaskListViewModel>(this, "BackToStartPage", (sender) => loadTasksLists());
        }

        public void loadTasksLists() {
            ListOfTasks.Clear();
            var database = DependencyService.Get<ISQLite>().GetConnection();
            var tasksListQuery = database.Table<TaskList>().Where(x => x.Id > 0); ;

            foreach (var list in tasksListQuery) {
                //load 0 from DB
                var countOpen =  database.Table<Task>().Count(x => x.TaskListId == list.Id && x.Fulfilled == false);
                var model = new TaskListViewModel(list.Id, list.Name, countOpen);
                ListOfTasks.Add(model);
            }
        }


        public async void addNewList(object sender, EventArgs e) {
            var createListController = new CreateTaskListView(ListOfTasks);
            await Navigation.PushModalAsync(createListController, true);
        }
        

        public async void ItemClicked(object sender, ItemTappedEventArgs e) {
            var item = (TaskListViewModel)e.Item;
            await Navigation.PushAsync(new TaskListView(item));
        }

        public void OnDelete(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            var id = (mi.BindingContext as TaskListViewModel).Id;

            var database = DependencyService.Get<ISQLite>().GetConnection();
            database.Delete<TaskList>(id);
            var tasks = database.Table<Task>().Where(x => x.TaskListId == id);

            foreach(var task in tasks) {
                database.Delete(task);
            }
            
            ListOfTasks.Remove(ListOfTasks.FirstOrDefault(X => X.Id == id));
        }

        public void OnClear(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            var viewModel = (mi.BindingContext as TaskListViewModel);
            var id = viewModel.Id;
            var database = DependencyService.Get<ISQLite>().GetConnection();
            var tasks = database.Table<Task>().Where(x => x.TaskListId == id);

            foreach (var task in tasks) {
                database.Delete(task);
            }

            viewModel.OpenItems = string.Format("{0} open items", 0); 

        }
    }

}
