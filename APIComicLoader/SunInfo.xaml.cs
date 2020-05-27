using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APIComicLoader
{
    /// <summary>
    /// Interaction logic for SunInfo.xaml
    /// </summary>
    public partial class SunInfo : Window
    {
        public SunInfo()
        {
            InitializeComponent();
        }

        private async void loadSunInfoBtn_Click(object sender, RoutedEventArgs e)
        {          
            if (lngInput.Text != "" || latInput.Text != "")
            {
                warningLabel.Visibility = Visibility.Collapsed;
                var sunResult = await SunProcessor.LoadSunInfo(lngInput.Text, latInput.Text);
                sunriseTxt.Text = $"Sunrise: { sunResult.Sunrise.ToLocalTime().ToShortTimeString()}";
                sunsetTxt.Text = $"Sunset: { sunResult.Sunset.ToLocalTime().ToShortTimeString()}";
            }
            else
            {
                warningLabel.Visibility = Visibility.Visible;
            }          
        }
  
        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
