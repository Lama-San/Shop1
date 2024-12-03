namespace Shop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ClassDb db = new ClassDb();
            MainPage = new NavigationPage( new MainPage(db));
        }
}
    }
