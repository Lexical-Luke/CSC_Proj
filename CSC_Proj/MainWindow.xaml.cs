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

namespace CSC_Proj
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

        //**Adding menu item functionality**

        //To add menu item functionality go to xaml and add 
        //<MenuItem Header="Font" HorizontalAlignment="Left" Width="140" Click="MenuItem_Click_Font"/>

        //THIS PART: Click="MenuItem_Click_Font"

        //With a descriptive name of what it is like 'Font'
        //plz always stick to the same naming conventions, 
        //this is a big project.

        #region File Menu Items

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New");
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save");
        }

        private void MenuItem_Click_SaveAs(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save As");
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open");
        }

        #endregion

        #region View Menu Items
        

        private void MenuItem_Click_Font(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Font");
        }

        private void MenuItem_Click_Size(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Size");
        }

        private void MenuItem_Click_Colour(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Colour");
        }

        #endregion

        
    }
}
