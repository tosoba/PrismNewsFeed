using System.Collections.Generic;
using Prism.Navigation;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using Prism.Commands;
using PrismNewsFeed.Constants;
using System.Threading.Tasks;
using Plugin.Connectivity;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

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
                FilteredSources = value;
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

        private List<Source> _filteredSources;
        public List<Source> FilteredSources
        {
            get => _filteredSources;
            set => SetProperty(ref _filteredSources, value);
        }

        private string _sourcesSearchText = string.Empty;
        public string SourcesSearchText
        {
            get => _sourcesSearchText;
            set
            {
                SetProperty(ref _sourcesSearchText, value);
                if (value.Any() && Sources != null)
                {
                    FilteredSources = Sources.Where(s => s.Name.ToLower().Contains(value.ToLower())).ToList();
                }
                else
                {
                    FilteredSources = Sources;
                }
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
            }
        }

        public override bool IsDataLoaded => Sources?.Any() ?? false;

        public override async Task LoadData()
        {
            await base.LoadData();
            Sources = await _newsService.LoadSources();
        }
    }
}
