using System;
using System.Windows;
using System.Windows.Threading;

namespace CodeLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content ="当前时间: " +  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void BtAddNew_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtUpDate_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void BtDel_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void BtSearch_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
