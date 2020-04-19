using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using CodeLibrary.Model;
using CodeLibrary.ViewModels;

namespace CodeLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel model = null;

        public MainWindow()
        {
            InitializeComponent();
            model = this.DataContext as MainWindowViewModel;
            
            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content ="当前时间: " +  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            model.GetDocumentCount();
        }
    }
}
