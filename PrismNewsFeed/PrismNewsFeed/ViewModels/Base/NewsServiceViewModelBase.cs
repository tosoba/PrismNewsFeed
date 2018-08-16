using Acr.UserDialogs;
using Plugin.Connectivity;
using Prism.Navigation;
using PrismNewsFeed.Services;
using System;
using System.Threading.Tasks;

namespace PrismNewsFeed.ViewModels
{
    public abstract class NewsServiceViewModelBase : LoadingViewModelBase
    {
        private static readonly string noConnectionMessage = "No internet connection.";

        protected INewsService _newsService;

        public NewsServiceViewModelBase(INavigationService navigationService, INewsService newsService) : base(navigationService)
        {
            _newsService = newsService;
            IsLoading = true;

            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
            {
                if (args.IsConnected && ConnectionLost && !IsDataLoaded)
                {
                    ConnectionLost = false;
                    await LoadData();
                }
            };
        }

        public abstract Task LoadData();

        public abstract bool IsDataLoaded { get; }

        public bool ConnectionLost { get; set; } = false;

        protected void ShowNoConnectionDialog()
        {
            UserDialogs.Instance.Toast(new ToastConfig(noConnectionMessage)
                        .SetDuration(TimeSpan.FromSeconds(2))
                        .SetPosition(ToastPosition.Bottom));
        }
    }
}
