using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;

namespace OS_Project.Forms
{
    public partial class splash : PhoneApplicationPage
    {
        public splash()
        {
            InitializeComponent();
        }


        void Splash()
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Delay(TimeSpan.FromSeconds(2));
            Splash(); //call
        }
    }
}