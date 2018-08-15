using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismNewsFeed.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SourceListCell : ViewCell
    {
        public SourceListCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(SourceListCell));
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(SourceListCell));
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value); 
        }
    }
}