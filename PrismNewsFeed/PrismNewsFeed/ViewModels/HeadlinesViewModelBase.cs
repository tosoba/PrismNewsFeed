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
    }
}
