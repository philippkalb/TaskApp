using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace TestApp2
{
    public partial class CreateListItem : ContentPage
    {

        ObservableCollection<ShoppingItem> shoppingItems = new ObservableCollection<ShoppingItem>();

        public CreateListItem(ObservableCollection<ShoppingItem> shoppingItems)
        {
            InitializeComponent();
            this.shoppingItems = shoppingItems;

        }

        public void OnAddButtonClicked(object sender, EventArgs e)
        {
            shoppingItems.Add(new ShoppingItem() { DisplayName = ListNameEntry.Text });
            ListNameEntry.Text = string.Empty;
        }

        public async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

    }
}
