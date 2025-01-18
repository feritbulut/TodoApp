using MyTodoApp.Views;

namespace MyTodoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListPage());

        }
    }
}
