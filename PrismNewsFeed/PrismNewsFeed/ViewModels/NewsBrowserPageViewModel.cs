using Prism.Navigation;
using PrismNewsFeed.Constants;
using PrismNewsFeed.Models;

namespace PrismNewsFeed.ViewModels
{
    public class NewsBrowserPageViewModel : ViewModelBase
    {
        public NewsBrowserPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private string _url = "https://www.google.com";
        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var headline = (Headline)parameters[NavigationKeys.headline];
            Url = headline.Url;
            Title = headline.Title;
        }
    }
}
