using Prism.Navigation;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using PrismNewsFeed.Constants;
using System.Threading.Tasks;

namespace PrismNewsFeed.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {
        public SearchPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Search";
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>(async (query) =>
                {
                    if (query.Any())
                    {
                        await NavigateToHeadlinesPage(query);
                        // save query if not exists
                        // update query last searched date if exists
                    }
                }));
            }
        }

        private async Task NavigateToHeadlinesPage(string query)
        {
            var parameters = new NavigationParameters();
            parameters.Add(NavigationKeys.query, query);
            await NavigationService.NavigateAsync("TopHeadlinesPage", parameters);
        }
    }
}
