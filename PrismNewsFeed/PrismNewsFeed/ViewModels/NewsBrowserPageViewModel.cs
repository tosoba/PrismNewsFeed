using Plugin.Connectivity;
using Prism.Navigation;
using PrismNewsFeed.Constants;
using PrismNewsFeed.Models;
using System.Runtime.CompilerServices;

namespace PrismNewsFeed.ViewModels
{
    public class NewsBrowserPageViewModel : ViewModelBase
    {
        public NewsBrowserPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private static readonly string defaultUrl = "https://www.google.com";

        private string _url = defaultUrl;
        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        private NavigationParameters _onNavigatingToParameters;

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            _onNavigatingToParameters = parameters;

            var headline = (Headline)parameters[NavigationKeys.headline];
            Url = headline.Url;
            Title = headline.Title;
        }

        public bool ConnectionLost { get; set; } = false;
    }
}
