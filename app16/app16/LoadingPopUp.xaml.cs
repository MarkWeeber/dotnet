using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace app16
{
    /// <summary>
    /// Логика взаимодействия для LoadingPopUp.xaml
    /// </summary>
    public partial class LoadingPopUp : Window
    {
        public LoadingPopUp()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        public void OnClose()
        {
            this.Close();
        }
    }
}
