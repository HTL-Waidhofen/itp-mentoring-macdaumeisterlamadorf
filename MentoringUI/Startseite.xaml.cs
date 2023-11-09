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

namespace MentoringUI
{
    /// <summary>
    /// Interaktionslogik für Startseite.xaml
    /// </summary>
    public partial class Startseite : Page
    {
        private string[] imagePaths;
        private int currentImageIndex;

        public Startseite()
        {
            InitializeComponent();

            imagePaths = new string[]
            {
                "img1.jfif",
                "img2.jpg",
                
            };

            currentImageIndex = 0;
            ShowCurrentImage();
        }

        private void ShowCurrentImage()
        {
            if (currentImageIndex >= 0 && currentImageIndex < imagePaths.Length)
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[currentImageIndex], UriKind.RelativeOrAbsolute));
                imageControl.Source = bitmapImage;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex >= imagePaths.Length)
                currentImageIndex = 0;
            ShowCurrentImage(); 
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            currentImageIndex--;
            if (currentImageIndex < 0)
                currentImageIndex = imagePaths.Length - 1;
            ShowCurrentImage();
        }
    }
}