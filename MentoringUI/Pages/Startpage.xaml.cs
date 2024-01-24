using System;
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
using System.Windows.Threading;

namespace MentoringUI
{
    /// <summary>
    /// Interaktionslogik für Startseite.xaml
    /// </summary>
    public partial class Startpage : Page
    {
        static int cnt = 0;

        private DispatcherTimer autoSwipeTimer;
        private int autoSwipeInterval = 3000;

        string[] pictures =
        {
            "Images/HTL-Logo.png",
            "Images/Beachtime.png",
            "Images/Strand.jpg"
        };

        public Startpage()
        {
            InitializeComponent();

            autoSwipeTimer = new DispatcherTimer();
            autoSwipeTimer.Tick += AutoSwipeTimer_Tick;
            autoSwipeTimer.Interval = TimeSpan.FromMilliseconds(autoSwipeInterval);

            autoSwipeTimer.Start();
        }

        private void AutoSwipeTimer_Tick(object sender, EventArgs e)
        {
            AutoSwipe();
        }

        private void AutoSwipe()
        {
            SwipeRight(null, null);
        }

        private void SwipeRight(object sender, RoutedEventArgs e)
        {
            cnt++;

            if (cnt >= pictures.Length)
            {
                cnt = 0;
            }

            imageDisplay.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(pictures[cnt]);
        }

        private void SwipeLeft(object sender, RoutedEventArgs e)
        {
            cnt--;

            if (cnt < 0)
            {
                cnt = pictures.Length - 1;
            }

            imageDisplay.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(pictures[cnt]);
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Login();
        }
    }
}