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

namespace Trigonometry_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double xval;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sinslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            xval = RadsToDeegs(Math.Asin(sinslider.Value));
            cosslider.Value = Math.Cos(xval);
            anglable.Content = $"Angle: {xval}";
        }

        private void cosslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            xval = RadsToDeegs(Math.Acos(sinslider.Value));
            sinslider.Value = Math.Sin(xval);
            anglable.Content = $"Angle: {xval}";
        }
        public static double RadsToDeegs(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }
    }
}
