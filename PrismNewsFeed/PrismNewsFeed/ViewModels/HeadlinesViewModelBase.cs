using Prism.Commands;
using Prism.Navigation;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using System.Collections.Generic;

namespace PrismNewsFeed.ViewModels
{
    public class HeadlinesViewModelBase : NewsServiceViewModelBase
    {
        public HeadlinesViewModelBase(INavigationService navigationService, INewsService newsService) : base(navigationService, newsService)
        {
        }

        private List<Headline> _headlines;
        public List<Headline> Headlines
        {
            get => _headlines;
            set
            {
                SetProperty(ref _headlines, value);
                IsLoading = false;
            }
        }

        private Headline _selectedHeadline;
        public Headline SelectedItem
        {
            get => _selectedHeadline;
            set
            {
                SetProperty(ref _selectedHeadline, value);
                NavigateToNewsPageCommand.Execute();
            }
        }

        public DelegateCommand NavigateToNewsPageCommand => new DelegateCommand(NavigateToNewsPage);

        private async void NavigateToNewsPage()
        {
            var parameters = new NavigationParameters();
            parameters.Add(Constants.NavigationKeys.headline, SelectedItem);
            await NavigationService.NavigateAsync("NewsBrowserPage", parameters);
        }
    }
}
