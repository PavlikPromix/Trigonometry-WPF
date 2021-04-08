using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Trigonometry_WPF
{
    public partial class MainWindow : Window
    {
        #region Properties
        public double Alpha;
        private double d;
        public double D { get { return d; } set { d = value; } }
        private double x;
        public double X { get { return x; } set { x = value; } }
        private double y;
        public double Y { get { return y; } set { y = value; } }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender == sinslider)
            {
                if (cosslider.Value != Math.Sqrt(1 - Math.Pow(sinslider.Value, 2)))
                {
                    cosslider.Value = Math.Sqrt(1 - Math.Pow(sinslider.Value, 2));
                }
            }
            else
            {
                if (sinslider.Value != Math.Sqrt(1 - Math.Pow(cosslider.Value, 2)))
                {
                    sinslider.Value = Math.Sqrt(1 - Math.Pow(cosslider.Value, 2));
                }
            }
            Alpha = Math.Acos(cosslider.Value);
            //coslable.Content = $"Cos: {Math.Round(cosslider.Value, 2)}";
            //sinlabel.Content = $"Sin: {Math.Round(sinslider.Value, 2)}";
            Draw();
        }
        public void Sync()
        {
            cosslider.Value = Math.Round(Math.Cos(Alpha), 2);
            anglable.Content = $"Angle: {Math.Round(RadToDeg(Alpha), 2)}";
            coslable.Content = $"Cos: {Math.Round(Math.Cos(Alpha), 2)}";
            sinlabel.Content = $"Sin: {Math.Round(Math.Sin(Alpha), 2)}";
        }
        public static double RadToDeg(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }
        public void Draw()
        {
            Update();
            demoLine.X2 = X;
            demoLine.Y2 = Y;
            Sync();
        }
        public void Update()
        {
            X = 200 + 100 * Math.Cos(Alpha);
            Y = 200 - 100 * Math.Sin(Alpha);

        }
        //arccos((x-200)/100)


        private void ellipse1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (MHoldCheckBox.IsChecked == true)
            {
                D = Math.Sqrt(Math.Pow((e.GetPosition(this).X - 200), 2) + Math.Pow((200 - e.GetPosition(this).Y), 2));
                Alpha = Math.Acos((e.GetPosition(this).X - 200) / D);
                Draw();
            }
        }

        private void ellipse1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MHoldCheckBox.IsChecked == false)
            {
                D = Math.Sqrt(Math.Pow((e.GetPosition(this).X - 200), 2) + Math.Pow((200 - e.GetPosition(this).Y), 2));
                Alpha = Math.Acos((e.GetPosition(this).X - 200) / D);
                Draw();
            }
        }
    }
}
