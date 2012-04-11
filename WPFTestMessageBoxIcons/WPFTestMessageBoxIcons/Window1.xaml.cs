using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTestMessageBoxIcons
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Asterisk", "test", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            MessageBox.Show("Error", "test", MessageBoxButton.OK, MessageBoxImage.Error);
            MessageBox.Show("Exclamation", "test", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            MessageBox.Show("Hand", "test", MessageBoxButton.OK, MessageBoxImage.Hand);
            MessageBox.Show("Information", "test", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("None", "test", MessageBoxButton.OK, MessageBoxImage.None);
            MessageBox.Show("Question", "test", MessageBoxButton.OK, MessageBoxImage.Question);
            MessageBox.Show("Stop", "test", MessageBoxButton.OK, MessageBoxImage.Stop);
            MessageBox.Show("Warning", "test", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
