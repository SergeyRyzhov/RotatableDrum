using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace RotatableDrum
{
    using System.Windows.Media.Animation;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Stopwatch sw;
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            sw.Stop();
            //rectangleSpeed.Width = 256 * sw.Elapsed.Milliseconds / 1000;
            Rotate((double)sw.Elapsed.TotalMilliseconds / 1000);
        }

        private void Rotate(double speed)
        {
           /* var sb = new Storyboard();
            var da = new DoubleAnimation(
                RotateArrow.Angle, RotateArrow.Angle + (360 * speed / 256), new Duration(new TimeSpan(0, 0, 0, 3)));
            sb.Children.Add(da);
            Storyboard.SetTarget(da, RotateArrow);
            Storyboard.SetTargetProperty(da, new PropertyPath(RotateTransform.AngleProperty) );
            //Storyboard.
            BeginStoryboard(sb);*/

            Storyboard s;
            s = (Storyboard)this.FindResource("RotateStory");
            (s.Children[0] as DoubleAnimation).From = RotateArrow.Angle;
            (s.Children[0] as DoubleAnimation).To = RotateArrow.Angle + (360 * speed) + 720 - 360 * (1 - speed);
            this.BeginStoryboard(s);
            //RotateArrow.Angle += (360 * speed / 256);
        }
    }
}
