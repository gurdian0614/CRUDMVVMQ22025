using CRUDMVVMQ22025.Views;

namespace CRUDMVVMQ22025
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
        }
    }
}
