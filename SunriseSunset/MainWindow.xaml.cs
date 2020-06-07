using APIData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SunriseSunset
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            APICommon.initilizeAPI();
        }

        private async void btn_GetData_Click(object sender, RoutedEventArgs e)
        {
            btn_GetData.Content = "Loading...";
            btn_GetData.IsEnabled = false;
            var sundata = await SunriseSunsetData.getData(txt_Longitude.Text,txt_Latitude.Text);

            if (sundata.status.ToLower() == "ok")
            {
                lbl_message.Content = "Success";
                lbl_message.Foreground = Brushes.Green;

                lbl_Sunrise.Content = $"Sunrise - {sundata.results.sunrise}";
                lbl_Sunset.Content =  $"Sunset - {sundata.results.sunset}";
            }
            else
            {
                lbl_message.Foreground = Brushes.Red;
                lbl_message.Content = sundata.status;
            }

            btn_GetData.Content = "Get Data";
            btn_GetData.IsEnabled = true;
        }
    }
}
