using Plugin.Connectivity;
using Prism.Navigation;
using PrismNewsFeed.Services;
using System.Threading.Tasks;

namespace PrismNewsFeed.ViewModels
{
    public abstract class NewsServiceViewModelBase : LoadingViewModelBase
    {
        protected INewsService _newsService;

        public NewsServiceViewModelBase(INavigationService navigationService, INewsService newsService) : base(navigationService)
        {
            _newsService = newsService;

            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                if (args.IsConnected && ConnectionLost && !IsDataLoaded)
                {
                    ConnectionLost = false;
                    await LoadData();
                }
                else if (!args.IsConnected && !ConnectionLost)
                {
                    ConnectionLost = true;
                }
                else if (args.IsConnected && ConnectionLost)
                {
                    ConnectionLost = false;
                }
            };
        }

        public virtual async Task LoadData()
        {
            IsLoading = true;
            return;
        }

        public abstract bool IsDataLoaded { get; }

        private bool _connectionLost = false;
        public bool ConnectionLost
        {
            get => _connectionLost;
            set => SetProperty(ref _connectionLost, value);
        }

        public string NoConnectionMessage => "No internet connection.";
    }
}
