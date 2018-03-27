using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismNewsFeed.ViewModels
{
	public class FeedsPageViewModel : ViewModelBase
    {
        public FeedsPageViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "PrismNews";
        }
    }
}
