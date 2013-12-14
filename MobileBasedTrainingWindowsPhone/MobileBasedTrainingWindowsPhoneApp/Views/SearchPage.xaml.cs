using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MobileBasedTrainingWindowsPhoneApp.ViewModels;
using UpdateControls.XAML;

namespace MobileBasedTrainingWindowsPhoneApp.Views
{
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var viewModel = ForView.Unwrap<SearchViewModel>(DataContext);
            if (viewModel != null)
                viewModel.Search();

            base.OnNavigatedTo(e);
        }
    }
}