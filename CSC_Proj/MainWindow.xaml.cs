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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using DataFormats = System.Windows.DataFormats;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using RichTextBox = System.Windows.Forms.RichTextBox;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

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



        //Add usefull multiuse features here and all global variables
        #region Program wide usefull methods

        //duh it clears the text box
        private void clear()
        {
            MainTextBox.SelectAll();

            MainTextBox.Selection.Text = "";
        }

        private string filePath = "";

        #endregion

        //Done
        //Only other text editors just cant open the rtf files that get saved
        #region File Menu Items

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            MainTextBox.SelectAll();
            string rtfBox = MainTextBox.Selection.Text;

            System.IO.StreamWriter saveWrite = new StreamWriter(filePath);

            saveWrite.Write(rtfBox);
            saveWrite.Close();

            //if you dont do this everything in the text box remains selected
            MainTextBox.Copy();
            MainTextBox.Paste();
        }

        private void MenuItem_Click_SaveAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (.txt)|*.txt|Rich Text Files(.rtf)|*.rtf|All Files (*.*)|*.*";
            saveFile.Title = "Save file...";

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = saveFile.ShowDialog();

            if (userClickedOK == true)
            {
                //because rtf.Text isn't a thing
                //copies the enitre richtextbox and then saves it as rtfBox because you can't do mainTexBox.Text
                MainTextBox.SelectAll();
                string rtfBox = MainTextBox.Selection.Text;

                System.IO.StreamWriter saveWrite = new StreamWriter(saveFile.FileName);
                //saveWrite.Write(MainTextBox.Document.ContentStart);       Doesn't really work should though

                filePath = saveFile.FileName;

                saveWrite.Write(rtfBox);
                saveWrite.Close();
            }
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|Rich Text Files(.rtf)|*.rtf";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Open A file...";

            //Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileDialog1.ShowDialog();

            //Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                ////first clear the text box
                clear();

                System.IO.FileStream fStream;
                TextRange range;

                if (System.IO.File.Exists(openFileDialog1.FileName))
                {
                    range = new TextRange(MainTextBox.Document.ContentStart, MainTextBox.Document.ContentEnd);
                    fStream = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.OpenOrCreate);
                    string format = "";
                    
                    if (openFileDialog1.FileName.EndsWith(".txt"))
                    {
                        format = DataFormats.Text;
                    }

                    else
                    {
                        format = DataFormats.Rtf;
                    }

                    filePath = openFileDialog1.FileName;

                    range.Load(fStream, format);

                    fStream.Close();
                }
            }        
        }

        #endregion

        //Done
        #region Edit Menu Items

        private void MenuItem_Click_Undo(object sender, RoutedEventArgs e)
        {
            MainTextBox.Undo();
        }

        private void MenuItem_Click_Redo(object sender, RoutedEventArgs e)
        {
            MainTextBox.Redo();
        }

        private void MenuItem_Click_Cut(object sender, RoutedEventArgs e)
        {
            MainTextBox.Cut();
        }

        private void MenuItem_Click_Copy(object sender, RoutedEventArgs e)
        {
            MainTextBox.Copy();
        }

        private void MenuItem_Click_Paste(object sender, RoutedEventArgs e)
        {
            MainTextBox.Paste();
        }

        private void MenuItem_Click_SelectAll(object sender, RoutedEventArgs e)
        {
            MainTextBox.SelectAll();
        }
        #endregion

        //Todo, well there is nothing todo
        #region Insert Menu Items
        #endregion
        
        //Todo all. (Sven working on font)
        #region Format Menu Items


        private void MenuItem_Click_Font(object sender, RoutedEventArgs e)
        {
            
            MainTextBox.Focus();
            System.Windows.Forms.FontDialog openFontDialog1 = new System.Windows.Forms.FontDialog();

            //bool? userClickedOK = openFontDialog1.ShowDialog();
            //userClickedOK == true
            if (openFontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fontName;
                float fontSize;
                string fontStyle = Convert.ToString(openFontDialog1.Font.Style);
                bool underline = openFontDialog1.Font.Underline;
                bool strikeout = openFontDialog1.Font.Strikeout;
                //MessageBox.Show(Convert.ToString(openFontDialog1.Font.Strikeout));
                fontName = openFontDialog1.Font.Name;
                fontSize = openFontDialog1.Font.Size;

                // fontStyle = openFontDialog1.Font.Style;

                //MainTextBox.FontSize = fontSize;
                //MainTextBox. = fontName;             
                //MainTextBox.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);

                TextRange text = new TextRange(MainTextBox.Selection.Start, MainTextBox.Selection.End);


                //                    Underline and crossthrough
                if (underline)
                {
                    text.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Underline);
                }
                if (strikeout)
                {
                    text.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Strikethrough);
                }

                if (!strikeout && !underline)
                { text.ApplyPropertyValue(Run.TextDecorationsProperty, null); }

                if (strikeout && !underline)
                {
                    text.ApplyPropertyValue(Run.TextDecorationsProperty, null);
                    text.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Strikethrough);
                }

                if (!strikeout && underline)
                {
                    text.ApplyPropertyValue(Run.TextDecorationsProperty, null);
                    text.ApplyPropertyValue(Run.TextDecorationsProperty, TextDecorations.Underline);
                }

                //                              Change style

                if (fontStyle == "Italic")
                    text.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic);

                if (fontStyle == "Bold, Italic")
                {
                    text.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Oblique);
                    text.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Bold);
                }

                if (fontStyle == "Bold")
                    text.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Bold);

                if (fontStyle == "Regular")
                {
                    text.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Normal);
                    text.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Normal);
                }

                //              Change Color

                System.Windows.Media.Color c = Colors.Red;
                SolidColorBrush brush = new SolidColorBrush(c);

                //text.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
            }
        }

        private void MenuItem_Click_Size(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Size");
            
        }

        private void MenuItem_Click_Colour(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Colour");
        }

        private void MenuItem_Click_Lower(object sender, RoutedEventArgs e)
        {
            string rtfBox = MainTextBox.Selection.Text;
            MainTextBox.Selection.Text = rtfBox.ToLower();
        }

        private void MenuItem_Click_Upper(object sender, RoutedEventArgs e)
        {
            string rtfBox = MainTextBox.Selection.Text;
            MainTextBox.Selection.Text = rtfBox.ToUpper(); ;
        }

        #endregion

        //Todo, well there is nothing todo
        #region Review Menu Items
        #endregion

    }
}
