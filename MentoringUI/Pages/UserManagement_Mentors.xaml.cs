using SQLiteDataAccess;
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
    public partial class UserManagement_Mentors: Page
    {
        SQLiteDataAccess.User user;
        string connectionString = @"Data Source=..\..\..\..\Database\itpmentoring.db;Version=3;";
        public UserManagement_Mentors(SQLiteDataAccess.User user)
        {
            InitializeComponent();
            this.user = user;
            List<Mentor> mentors = SQLiteDataAccess.SqliteDataAccess.LoadMentors(connectionString);
            mentors_lbx.Items.Clear();
            for (int i = 0; i < mentors.Count; i++) mentors_lbx.Items.Add(mentors[i].ToString());
        }
        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings(8, user);
        }

        private void student_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new UserManagement_Students(user);
        }

        private void mentor_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new UserManagement_Mentors(user);
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(mentors_lbx.SelectedItem.ToString()))
            {
                var dialog = new InputDialog(mentors_lbx.SelectedItem.ToString());

                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    MessageBoxResult mResult = MessageBox.Show("Sind Sie sicher, dass Sie diesen Mentor bearbeiten wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (mResult == MessageBoxResult.Yes)
                    {
                        mentors_lbx.SelectedItem = dialog.InputText;
                        SqliteDataAccess.UpdateMentor(connectionString, new Mentor(int.Parse(mentors_lbx.SelectedItem.ToString().Split('-')[0]), dialog.InputText.Split('-')[1]));
                        List<Mentor> mentors = SQLiteDataAccess.SqliteDataAccess.LoadMentors(connectionString);
                        mentors_lbx.Items.Clear();
                        for (int i = 0; i < mentors.Count; i++) mentors_lbx.Items.Add(mentors[i].ToString());
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
                if(mentors_lbx.SelectedItems.Count == 1)
                {
                    MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diesen Mentor löschen wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        DeleteSelectedItems();
                    }
                }
                else
                {
                    MessageBox.Show("Wählen Sie einen Mentoren aus, um diesen zu löschen", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
        }
        private void DeleteSelectedItems()
        {
            var selectedItems = new List<object>(mentors_lbx.SelectedItems.Cast<object>());

            foreach (var item in selectedItems)
            {
                mentors_lbx.Items.Remove(item);
                List<Mentor> allMentors = SqliteDataAccess.LoadMentors(connectionString);
                SqliteDataAccess.DeleteMentor(connectionString, int.Parse(item.ToString().Split("-")[0]));
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeight = e.NewSize.Height - 180;
            mentors_lbx.Height = newHeight;
        }
        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Admin(user);
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
