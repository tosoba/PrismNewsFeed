﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismNewsFeed.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadlineListCell : ViewCell
    {
        public HeadlineListCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(HeadlineListCell));
        public string ImageUrl
        {
            get => (string)GetValue(ImageUrlProperty);
            set => SetValue(ImageUrlProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(HeadlineListCell));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty PublishedFormattedProperty = BindableProperty.Create(nameof(PublishedFormatted), typeof(string), typeof(HeadlineListCell));
        public string PublishedFormatted
        {
            get => (string)GetValue(PublishedFormattedProperty);
            set => SetValue(PublishedFormattedProperty, value);
        }

        public static readonly BindableProperty AuthorSourceProperty = BindableProperty.Create(nameof(AuthorSource), typeof(string), typeof(HeadlineListCell));
        public string AuthorSource
        {
            get => (string)GetValue(AuthorSourceProperty);
            set => SetValue(AuthorSourceProperty, value);
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(HeadlineListCell));
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }
    }
}