using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace app14
{
    delegate void del(int x);
    public partial class Testing : Window
    {
        public Testing()
        {
            InitializeComponent();
            del xxs = Methodx;
            xxs(3);
        }

        public void Methodx(int x)
        {
            Debug.WriteLine($"given number: {x}");
        }
    }
}
