using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismNewsFeed.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedQueryListCell : ViewCell
    {
        public SavedQueryListCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty QueryProperty = BindableProperty.Create(nameof(Query), typeof(string), typeof(HeadlineListCell));
        public string Query
        {
            get => (string)GetValue(QueryProperty);
            set => SetValue(QueryProperty, value);
        }
    }
}