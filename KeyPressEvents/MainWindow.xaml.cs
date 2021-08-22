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

namespace KeyPressEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if ((bool)chkIgnoreRepeat.IsChecked && e.IsRepeat) return;

            string message = //"At: " + e.Timestamp.ToString() +
                "Event: " + e.RoutedEvent + " " +
                " Key: " + e.Key;
            lstMessages.Items.Add(message);
        }

        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            string message = //"At: " + e.Timestamp.ToString() +
           "Event: " + e.RoutedEvent + " " +
           " Text: " + e.Text;
            lstMessages.Items.Add(message);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            string message =
               "Event: " + e.RoutedEvent;
            lstMessages.Items.Add(message);
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Clear();
        }
    }
}
