using Acr.UserDialogs;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using PrismNewsFeed.Models;
using PrismNewsFeed.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismNewsFeed.ViewModels
{
    public abstract class HeadlinesViewModelBase : NewsServiceViewModelBase
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
            if (CrossConnectivity.Current.IsConnected)
            {
                var parameters = new NavigationParameters();
                parameters.Add(Constants.NavigationKeys.headline, SelectedItem);
                await NavigationService.NavigateAsync("NewsBrowserPage", parameters);
            }
            else
            {
                ShowNoConnectionDialog();
            }
        }

        private void ShowNoConnectionDialog()
        {
            UserDialogs.Instance.Toast(new ToastConfig(NoConnectionMessage)
                        .SetDuration(TimeSpan.FromSeconds(2))
                        .SetPosition(ToastPosition.Bottom));
        }

        public override bool IsDataLoaded => Headlines?.Any() ?? false;
    }
}
