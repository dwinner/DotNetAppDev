﻿using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PageNavigation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThirdPage : BasePage
    {
        public ThirdPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Data = e.Parameter as string;
        }

        private string _data;
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }
    }
}
