using System.Collections.Generic;
using Prism.Navigation;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using Prism.Commands;
using PrismNewsFeed.Constants;
using System.Threading.Tasks;
using Plugin.Connectivity;
using System.Linq;

namespace PrismNewsFeed.ViewModels
{
    public class SourcesPageViewModel : NewsServiceViewModelBase
    {
        private List<Source> _sources;
        public List<Source> Sources
        {
            get { return _sources; }
            set
            {
                SetProperty(ref _sources, value);
                IsLoading = false;
            }
        }

        private Source _selectedSource;
        public Source SelectedItem
        {
            get
            {
                return _selectedSource;
            }
            set
            {
                SetProperty(ref _selectedSource, value);
                NavigateToTopHeadlinesPageCommand.Execute();
            }
        }

        public DelegateCommand NavigateToTopHeadlinesPageCommand => new DelegateCommand(NavigateToTopHeadlinesPage);

        private async void NavigateToTopHeadlinesPage()
        {
            var parameters = new NavigationParameters();
            parameters.Add(NavigationKeys.headlinesSource, SelectedItem);
            await NavigationService.NavigateAsync("TopHeadlinesPage", parameters);
        }

        public SourcesPageViewModel(INavigationService navigationService, INewsService newsService) : base(navigationService, newsService)
        {
            Title = "Sources";
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            if (CrossConnectivity.Current.IsConnected)
            {
                await LoadData();
            }
            else
            {
                ConnectionLost = true;
                ShowNoConnectionDialog();
            }
        }

        public override bool IsDataLoaded => Sources?.Any() ?? false;

        public override async Task LoadData()
        {
            Sources = await _newsService.LoadSources();
        }
    }
}
