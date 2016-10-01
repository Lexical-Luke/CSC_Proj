using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

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

        #region Program wide usefull methods

        //duh it clears the text box
        private void clear()
        {
            MainTextBox.SelectAll();

            MainTextBox.Selection.Text = "";
        }


        #endregion

        #region File Menu Items

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save");
        }

        private void MenuItem_Click_SaveAs(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save As");

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (.txt)|*.txt|Rich Text Files(.rtf)|*.rtf|All Files (*.*)|*.*";
            saveFile.Title = "Save file...";

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = saveFile.ShowDialog();

            if (userClickedOK == true)
            {
                System.IO.StreamWriter saveWrite = new StreamWriter(saveFile.FileName);
                saveWrite.Write(MainTextBox.Document.ContentStart);
                saveWrite.Close();
            }
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {     
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|Rich Text Files(.rtf)|*.rtf|All Files (*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Open A file...";

            //if you want to select multiple files, but why?
            //openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                //first clear the text box
                clear();

                // Open the selected file to read.
                System.IO.StreamReader reader = new System.IO.StreamReader(openFileDialog1.FileName);
                MainTextBox.AppendText(reader.ReadToEnd());
                //var t = new TextRange(MainTextBox.Document.ContentStart, MainTextBox.Document.ContentEnd);
                //MainTextBox.AppendText(t.Text);
                reader.Close();
            }

        }

        #endregion

        #region Edit Menu Items

        private void MenuItem_Click_Undo(object sender, RoutedEventArgs e)
        {
            MainTextBox.Undo();
        }

        private void MenuItem_Click_Redo(object sender, RoutedEventArgs e)
        {
            MainTextBox.Redo();
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
