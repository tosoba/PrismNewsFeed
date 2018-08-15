using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismNewsFeed.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using PrismNewsFeed.Models;
using Xamarin.Forms;
using System.Windows.Input;

namespace PrismNewsFeed.ViewModels
{
    public class SearchPageViewModel : HeadlinesViewModelBase
    {
        public SearchPageViewModel(INavigationService navigationService, INewsService headlinesService) : base(navigationService, headlinesService)
        {
            Title = "Search";
            IsLoading = false;
            Headlines = new List<Headline>();
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((query) =>
                {
                    if (query.Any()) SearchForHeadlines(query);
                }));
            }
        }

        private async void SearchForHeadlines(string query)
        {
            IsLoading = true;
            Headlines = await _newsService.SearchHeadlines(query);
        }
    }
}
