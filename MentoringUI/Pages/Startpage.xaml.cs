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
    }
}