using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;

namespace app12
{
    public partial class Login : Window
    {
        private Resource userResource;
        private List<User> userDatabase;
        public Login()
        {
            InitializeComponent();
            userResource = new Resource("users.json");
            userDatabase = new List<User>();
            User.Refresh();
            userDatabase = userResource.RetrieveFromJson<List<User>>(); // try reading user database
            if (userDatabase == null)   // if file not found then create default values for users
            {
                Debug.WriteLine("users db file not found, making default values");
                userDatabase = new List<User>();
                userDatabase.Add(new Consultant("Ricardo"));
                userDatabase.Add(new Consultant("Daniel"));
                userDatabase.Add(new Manager("Mike"));
                userDatabase.Add(new Manager("Seaun"));
                userResource.SaveToJson(userDatabase); // saving json
            }
            SelectUserComboBox.ItemsSource = userDatabase;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(SelectUserComboBox.SelectedItem != null)
            {
                Buffer.SelectedUser = SelectUserComboBox.SelectedItem as User;
                Window mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }
    }
}
