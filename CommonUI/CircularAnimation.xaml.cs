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

namespace CommonUI
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class CircularAnimation : UserControl
    {
        static CircularAnimation instance = null;
        public static CircularAnimation Instance()
        {
            if (instance == null)
            {
                instance = new CircularAnimation();
                instance.HorizontalAlignment = HorizontalAlignment.Stretch;
                instance.VerticalAlignment = VerticalAlignment.Stretch;
            }
            return instance;
        }
        public void Begin(Window window = null)
        {
            if (instance.Parent != null)
            {
                Grid parent = (Grid)instance.Parent;
                parent.Children.Remove(instance);
            }

            if (window == null)
            {
                Grid main = (Grid)Application.Current.MainWindow.Content;
                main.Children.Add(instance);
            }
            else
            {
                Grid main = (Grid)window.Content;
                main.Children.Add(instance);
            }
            this.Visibility = Visibility.Visible;
        }

        public void Stop()
        {
            this.Visibility = Visibility.Hidden;
        }
        public CircularAnimation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 环形宽度
        /// </summary>
        public double ArcThickness
        {
            get { return (double)GetValue(ArcThicknessProperty); }
            set { SetValue(ArcThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ArcThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArcThicknessProperty =
            DependencyProperty.Register("ArcThickness", typeof(double), typeof(CircularAnimation), new PropertyMetadata(30D,
                new PropertyChangedCallback(ThicknessChange)));

        private static void ThicknessChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CircularAnimation).arc.ArcThickness = (double)e.NewValue;
        }

        /// <summary>
        /// 提示信息字体大小
        /// </summary>
        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register("LabelFontSize", typeof(double), typeof(CircularAnimation), new PropertyMetadata(24D,
                new PropertyChangedCallback(LabelFontSizeChange)));

        public static void LabelFontSizeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CircularAnimation).msg.FontSize = (double)e.NewValue;
        }

        public Brush LabelForeground
        {
            get { return (Brush)GetValue(LabelForegroundProperty); }
            set { SetValue(LabelForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelForegroundProperty =
            DependencyProperty.Register("LabelForeground", typeof(Brush), typeof(CircularAnimation), new PropertyMetadata(Brushes.Black,
                new PropertyChangedCallback(LabelForegroundChange)));

        public static void LabelForegroundChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CircularAnimation).msg.Foreground = (Brush)e.NewValue;
        }

        public object LabelMessage
        {
            get { return (string)GetValue(LabelMessageProperty); }
            set { SetValue(LabelMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelMessageProperty =
            DependencyProperty.Register("LabelMessage", typeof(string), typeof(CircularAnimation), new PropertyMetadata("Loading",
                new PropertyChangedCallback(LabelMessageChange)));

        public static void LabelMessageChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CircularAnimation).msg.Content = e.NewValue;
        }
    }
}
