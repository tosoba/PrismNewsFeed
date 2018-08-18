using Prism.Navigation;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using PrismNewsFeed.Constants;
using System.Threading.Tasks;
using PrismNewsFeed.Models;
using System.Collections.Generic;
using System;
using Prism.Commands;

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
                    var trimmed = query.Trim();
                    if (trimmed.Any())
                    {
                        await NavigateToHeadlinesPage(trimmed);

                        Database.InsertOrUpdateQuery(new SavedQuery
                        {
                            Query = trimmed,
                            LastSearched = DateTime.Now
                        });

                        PreviousQueries = Database.GetQueries();
                    }
                }));
            }
        }

        private SavedQuery _selectedItem;
        public SavedQuery SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                SetProperty(ref _selectedItem, value);
                NavigateToTopHeadlinesPageCommand.Execute();
            }
        }

        public DelegateCommand NavigateToTopHeadlinesPageCommand => new DelegateCommand(NavigateToHeadlinesPage);

        private List<SavedQuery> _previousQueries = Database.GetQueries();
        public List<SavedQuery> PreviousQueries
        {
            get => _previousQueries;
            set => SetProperty(ref _previousQueries, value);
        }

        private async void NavigateToHeadlinesPage()
        {
            var parameters = new NavigationParameters();
            parameters.Add(NavigationKeys.query, SelectedItem.Query);
            await NavigationService.NavigateAsync("TopHeadlinesPage", parameters);
        }

        private async Task NavigateToHeadlinesPage(string query)
        {
            var parameters = new NavigationParameters();
            parameters.Add(NavigationKeys.query, query);
            await NavigationService.NavigateAsync("TopHeadlinesPage", parameters);
        }
    }
}
