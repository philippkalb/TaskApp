using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestApp2
{
    public partial class TaskList : ContentPage
    {
        ObservableCollection<ShoppingItem> employees = new ObservableCollection<ShoppingItem>();

        public TaskList(ListofTasks item)
        {
            InitializeComponent();

            EmployeeView.ItemsSource = employees;
            employees.Add(new ShoppingItem { DisplayName = item.DisplayName });
        }

        public async void addNewItem(object sender, EventArgs e)
        {
            var createListController = new CreateListItem(employees);
            await Navigation.PushModalAsync(createListController, true);
        }

    }


    public class ShoppingItem
    {
        public string DisplayName { get; set; }
    }

}
