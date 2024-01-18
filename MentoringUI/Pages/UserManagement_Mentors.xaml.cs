using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Interaktionslogik für UserManagement.xaml
    /// </summary>
    public partial class UserManagement_Mentors : Page
    {
        public UserManagement_Mentors()
        {
            InitializeComponent();
        }
        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings();
        }

        private void student_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new UserManagement_Students();
        }

        private void mentor_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new UserManagement_Mentors();
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)courseEdit_lbx.SelectedItem;

            if (selectedItem != null)
            {
                var dialog = new InputDialog(selectedItem.Content.ToString());

                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    MessageBoxResult mResult = MessageBox.Show("Sind Sie sicher, dass Sie diesen Mentor bearbeiten wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mResult == MessageBoxResult.Yes)
                    {
                        selectedItem.Content = dialog.InputText;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Mentor aus, um ihn zu bearbeiten.");
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
                if (courseEdit_lbx.SelectedItems.Count > 1)
                {
                    MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diese Mentoren löschen wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        DeleteSelectedItems();
                    }
                }
                else if(courseEdit_lbx.SelectedItems.Count == 1)
                {
                    MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diesen Mentor löschen wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        DeleteSelectedItems();
                    }
            }
                else
                {
                    MessageBox.Show("Wählen Sie Mentoren aus, um sie zu löschen", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
        }
        private void DeleteSelectedItems()
        {
            var selectedItems = new List<object>(courseEdit_lbx.SelectedItems.Cast<object>());

            foreach (var item in selectedItems)
            {
                courseEdit_lbx.Items.Remove(item);
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeight = e.NewSize.Height - 180;
            courseEdit_lbx.Height = newHeight;
        }
    }
    public partial class InputDialog : Window
    {
        private TextBox textBox;
        private Button OKButton;
        private Button CancelButton;

        public string InputText { get; private set; }

        public InputDialog(string initialText)
        {
            InitializeComponent();
            textBox.Text = initialText;
        }

        private void InitializeComponent()
        {
            textBox = new TextBox();
            OKButton = new Button() { Content = "OK" };
            CancelButton = new Button() { Content = "Cancel" };

            OKButton.Click += OKButton_Click;
            CancelButton.Click += CancelButton_Click;

            StackPanel panel = new StackPanel();
            panel.Children.Add(textBox);
            panel.Children.Add(OKButton);
            panel.Children.Add(CancelButton);


            Content = panel;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            InputText = textBox.Text;
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

}
