using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismNewsFeed.ViewModels
{
	public class TopHeadlinesPageViewModel : ViewModelBase
	{
        private ITopHeadlinesService _topHeadlinesService;

        private List<Headline> _topHeadlines;
        public List<Headline> TopHeadlines
        {
            get { return _topHeadlines; }
            set
            {
                SetProperty(ref _topHeadlines, value);
                IsLoading = false;
            }
        }

        private bool _isLoading = true;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        public TopHeadlinesPageViewModel(INavigationService navigationService, ITopHeadlinesService topHeadlinesService) : base(navigationService)
        {
            Title = "Top headlines";
            _topHeadlinesService = topHeadlinesService;
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            TopHeadlines = await _topHeadlinesService.LoadTopHeadlines();
        }
    }
}
