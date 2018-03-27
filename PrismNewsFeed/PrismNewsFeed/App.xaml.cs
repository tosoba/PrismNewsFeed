using Prism;
using Prism.Ioc;
using PrismNewsFeed.ViewModels;
using PrismNewsFeed.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using PrismNewsFeed.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismNewsFeed
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/FeedsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<FeedsPage>();
            containerRegistry.RegisterForNavigation<TopHeadlinesPage>();
            containerRegistry.RegisterForNavigation<SearchPage>();

            containerRegistry.RegisterInstance<ITopHeadlinesService>(new TopHeadlinesService());
        }
    }
}
