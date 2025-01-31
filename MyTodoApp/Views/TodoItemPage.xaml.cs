using MyTodoApp.Data;
using MyTodoApp.Models;

namespace MyTodoApp.Views;

public partial class TodoItemPage : ContentPage
{
	public TodoItemPage()
	{
		InitializeComponent();
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {
		var todoItem = (TodoItem)BindingContext;
		TodoItemDatabase database = await TodoItemDatabase.Instance;
		await database.SaveItemAsync(todoItem);
		await Navigation.PopAsync();
    }

	async void OnDeleteClicked(object sender, EventArgs e)
	{
		var todoItem = (TodoItem)BindingContext;
        TodoItemDatabase database = await TodoItemDatabase.Instance;
        await database.DeleteItemAsync(todoItem);
        await Navigation.PopAsync();
	
	}

	async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}