using Prism.Commands;
using Prism.Navigation;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using System.Collections.Generic;

namespace PrismNewsFeed.ViewModels
{
    public class HeadlinesViewModelBase : ViewModelBase
    {
        protected IHeadlinesService _headlinesService;

        public HeadlinesViewModelBase(INavigationService navigationService, IHeadlinesService headlinesService) : base(navigationService)
        {
            _headlinesService = headlinesService;
        }

        private List<Headline> _headlines;
        public List<Headline> Headlines
        {
            get { return _headlines; }
            set
            {
                SetProperty(ref _headlines, value);
                IsLoading = false;
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private Headline _selectedHeadline;
        public Headline SelectedItem
        {
            get
            {
                return _selectedHeadline;
            }
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
            parameters.Add(Constants.Constants.urlParameterKey, SelectedItem.Url);
            await NavigationService.NavigateAsync("NewsBrowserPage", parameters);
        } 
    }
}
