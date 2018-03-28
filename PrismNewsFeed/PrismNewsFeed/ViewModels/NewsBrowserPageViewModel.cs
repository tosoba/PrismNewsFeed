using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismNewsFeed.ViewModels
{
	public class NewsBrowserPageViewModel : ViewModelBase
	{
        public NewsBrowserPageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "News";
        }

        private string _url = "https://www.google.pl/webhp?source=search_app&gfe_rd=cr&dcr=0&ei=8hu8Wu2lLNPX8gfgp52wCg";
        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Url = (string)parameters[Constants.Constants.urlParameterKey];
        }
    }
}
