using System.Diagnostics;
using System;
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
using System.Windows.Threading;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Canvas canvas;
        private Random random = new Random();
        private DispatcherTimer timer = new DispatcherTimer();
        private Stopwatch stopwatch = new Stopwatch();
        private int drawCount = 0;
        public MainWindow()
        {
            InitializeComponent();

            canvas = new Canvas();
            Content = canvas;

            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();

            // Start measuring performance
            stopwatch.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            canvas.Children.Clear();
            for (int i = 0; i < 100; i++)
            {
                var shape = new Ellipse
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.Blue
                };

                Canvas.SetLeft(shape, random.NextDouble() * canvas.ActualWidth);
                Canvas.SetTop(shape, random.NextDouble() * canvas.ActualHeight);
                canvas.Children.Add(shape);
                drawCount++;
            }

            
            if (drawCount == 100)
            {
                stopwatch.Stop();
                MessageBox.Show($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms", "Drawing Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
            }
        }

    }
}
