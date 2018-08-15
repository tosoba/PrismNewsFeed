using Xamarin.Forms;

namespace PrismNewsFeed.Views
{
    public partial class NewsBrowserPage : ContentPage
    {
        public NewsBrowserPage()
        {
            InitializeComponent();
        }

        private void newsWebView_onNavigated(object sender, WebNavigatedEventArgs eventArgs)
        {
            webViewLoadingIndicator.IsVisible = false;
            newsWebView.IsVisible = true;
        }

        private void newsWebView_onNavigating(object sender, WebNavigatingEventArgs eventArgs)
        {
            webViewLoadingIndicator.IsVisible = true;
            newsWebView.IsVisible = false;
        }
    }
}
