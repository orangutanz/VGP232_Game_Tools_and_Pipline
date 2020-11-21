using Microsoft.Win32;
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
using System.Xml.Serialization;
using TextureAtlasLib;

// Assignment 3
// NAME: Yuhan Ma
// STUDENT NUMBER: 1930014
// MARKS: 68/100 Good effort. The save and load xml should be implementation in the TextureAtlasLib, and it wasn't implemented correctly. Browse button is suppose to set 2 textboxes the OutputFile and the OutputDirectory. It suppose to serialize the Spritesheet class from the SaveDialog.FileName not the Spritesheet.OuptutFile. Generate doesn't have a try catch to show the messagebox when an exception is thrown and when it succeeds it should show a messsage box to take the user to the folder. The OutputDirectory is not data binded properly so an exception is thrown from validation when you Generate.
// Does it compile? Yes
// Does it produce the correct results? No
// Is using databinding? Yes, but the outputDirectory wasn't binded.
// Does the UI look like the mock up? Yes

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Spritesheet MySpriteSheets { get; set; }
        // LC: there should be another property here for the file to save or load.

        public MainWindow()
        {
            InitializeComponent();

            // LC: should be set after the spritesheet is initialized.
            DataContext = MySpriteSheets;
            MySpriteSheets = new Spritesheet();
            // LC: add a default constructor with the list initialization
            MySpriteSheets.InputPaths = new List<String>();
            lbImages.ItemsSource = MySpriteSheets.InputPaths;
            
        }



        private void AddPressed(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PNG Images | *.png";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == true)
            {
                foreach (var i in openFile.FileNames)
                {
                    MySpriteSheets.InputPaths.Add(i);
                }
                lbImages.Items.Refresh();
            }
        }

        private void RemovePressed(object sender, RoutedEventArgs e)
        {
            if(lbImages.SelectedIndex == -1)
            {
                return;
            }
            MySpriteSheets.InputPaths.RemoveAt(lbImages.SelectedIndex);
            lbImages.Items.Refresh();
        }

        private void GeneratePressed(object sender, RoutedEventArgs e)
        {
            // LC: wrap this in try catch because it will throw an exception if the properties are not set properly
            // also when this succeeds it should show a message box asking if the user wants to go to the output folder.
            MySpriteSheets.Generate(true);
        }

        private void BrowsePressed(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == true)
            {
                // LC: System.IO.Path.GetFileName and System.IO.Path.GetDirectoryName
                // LC: this should be databinded so you just need to update MySpriteSheets properties with the outputFile and outputDirectory
                tbOutputDir.Text = saveFile.FileName;
                MySpriteSheets.OutputFile = saveFile.FileName;
            }
        }

        private void MenuNew(object sender, RoutedEventArgs e)
        {
            MySpriteSheets.Columns = 0;
            MySpriteSheets.OutputFile = null;
            MySpriteSheets.OutputDirectory = null;
            MySpriteSheets.IncludeMetaData = false;
            MySpriteSheets.InputPaths.Clear();
            lbImages.Items.Refresh();
        }
        private void MenuOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                // LC: this should be added to the textureatlaslib spritesheet class in Load function.
                XmlSerializer xml = new XmlSerializer(typeof(List<String>));
                try
                {
                    using (StreamReader reader = new StreamReader(openFile.FileName))
                    {
                        // LC: we are not deserializing the list of images use, but the entire Spritesheet classs.
                        MySpriteSheets.InputPaths.Clear();
                        MySpriteSheets.InputPaths = (List<String>)xml.Deserialize(reader);
                    }
                }
                catch (Exception)
                {
                    // throw an exception of why it wasn't able to be saved.
                    // LC: show an error saying it wasn't able to open the file.
                }

            }
        }

        private void MenuSave(object sender, RoutedEventArgs e)
        {
            // LC: Add this in Spritesheet class in a method called Save
            XmlSerializer xml = new XmlSerializer(typeof(Spritesheet));
            try
            {
                // LC: 
                using (StreamWriter writer = new StreamWriter(MySpriteSheets.OutputFile))
                {
                    xml.Serialize(writer, MySpriteSheets);                     
                }
            }
            catch (Exception)
            {
                // throw an exception of why it wasn't able to be saved.
                // and catch this exception and put the message into a MessageBox
            }
        }
    

        private void MenuSaveAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == true)
            {
                // LC: you're not setting any of the properties, but the label that says the file name.
                tbOutputDir.Text = saveFile.FileName;
                MySpriteSheets.OutputFile = saveFile.FileName;
            }
            // LC: should be inside the body of the if statement.
            MenuSave(sender, e);
        }

        private void MenuExit(object sender, RoutedEventArgs e)
        {
            // LC: missing implementation
        }
    }
}
