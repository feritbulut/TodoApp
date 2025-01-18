using MyTodoApp.Data;
using MyTodoApp.Models;

namespace MyTodoApp.Views;

public partial class TodoListPage : ContentPage
{
	public TodoListPage()
	{
		InitializeComponent();

       
    }

	async void OnItemAdded(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TodoItemPage
        {
            BindingContext = new TodoItem()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = e.SelectedItem as TodoItem
            });
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        listView.ItemsSource = await database.GetItemsAsync();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var todoItem = button.BindingContext as TodoItem;

        if (todoItem != null)
        {
            // Done özelliðini tersine çeviriyoruz (true ise false yapar, false ise true yapar)
            todoItem.Done = !todoItem.Done;

            // Veritabanýnda güncelleme yapýyoruz
            TodoItemDatabase database = await TodoItemDatabase.Instance;
            await database.SaveItemAsync(todoItem);
        }
    }



}