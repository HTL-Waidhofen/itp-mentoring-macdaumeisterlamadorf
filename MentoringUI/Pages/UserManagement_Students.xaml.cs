using SQLiteDataAccess;
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
    /// Interaktionslogik für UserManagement.xaml
    /// </summary>
    public partial class UserManagement_Students : Page
    {
        SQLiteDataAccess.User user;
        string connectionString = @"Data Source=..\..\..\..\Database\itpmentoring.db;Version=3;";
        public UserManagement_Students(SQLiteDataAccess.User user)
        {
            InitializeComponent();
            this.user = user;
            List<User> users = SQLiteDataAccess.SqliteDataAccess.LoadUsers(connectionString);
            students_lbx.Items.Clear();
            for (int i = 0; i < users.Count; i++) students_lbx.Items.Add(users[i].ToString());
        }

        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Settings(7, user);
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
            try
            {
                if (!string.IsNullOrEmpty(students_lbx.SelectedItem.ToString()))
                {
                    var dialog = new InputDialog(students_lbx.SelectedItem.ToString());

                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        MessageBoxResult mResult = MessageBox.Show("Sind Sie sicher, dass Sie diesen Schüler bearbeiten wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (mResult == MessageBoxResult.Yes)
                        {
                            students_lbx.SelectedItem = dialog.InputText;
                            SqliteDataAccess.UpdateUser(connectionString, new User(int.Parse(students_lbx.SelectedItem.ToString().Split('-')[0]), char.Parse(dialog.InputText.Split('-')[1]), dialog.InputText.Split('-')[2], dialog.InputText.Split('-')[3], dialog.InputText.Split('-')[4], dialog.InputText.Split('-')[5], dialog.InputText.Split('-')[6], int.Parse(dialog.InputText.Split('-')[7]), dialog.InputText.Split('-')[8]));
                            List<User> mentors = SQLiteDataAccess.SqliteDataAccess.LoadUsers(connectionString);
                            students_lbx.Items.Clear();
                            for (int i = 0; i < mentors.Count; i++) students_lbx.Items.Add(mentors[i].ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie einen Schüler aus, um ihn zu bearbeiten.");
                }
            }
            catch(IndexOutOfRangeException ex) 
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (students_lbx.SelectedItems.Count == 1)
            {
                MessageBoxResult result = MessageBox.Show("Sind Sie sicher, dass Sie diesen Schüler löschen wollen?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    DeleteSelectedItems();
                }
            }
            else
            {
                MessageBox.Show("Wählen Sie einen Schüler aus, um diesen zu löschen", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteSelectedItems()
        {
            var selectedItems = new List<object>(students_lbx.SelectedItems.Cast<object>());

            foreach (var item in selectedItems)
            {
                students_lbx.Items.Remove(item);
                List<User> allUser = SqliteDataAccess.LoadUsers(connectionString);
                SqliteDataAccess.DeleteUser(connectionString, int.Parse(item.ToString().Split("-")[0]));
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeight = e.NewSize.Height - 180;
            students_lbx.Height = newHeight;
        }
        private void return_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Content = new Admin(user);
        }
    }
}