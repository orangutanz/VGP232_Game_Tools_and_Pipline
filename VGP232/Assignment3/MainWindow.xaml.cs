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

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Spritesheet MySpriteSheets { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = MySpriteSheets;
            MySpriteSheets = new Spritesheet();
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
            MySpriteSheets.Generate(true);
        }

        private void BrowsePressed(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == true)
            {
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
                XmlSerializer xml = new XmlSerializer(typeof(List<String>));
                try
                {
                    using (StreamReader reader = new StreamReader(openFile.FileName))
                    {
                        MySpriteSheets.InputPaths.Clear();
                        MySpriteSheets.InputPaths = (List<String>)xml.Deserialize(reader);
                    }
                }
                catch (Exception)
                {
                }

            }
        }

        private void MenuSave(object sender, RoutedEventArgs e)
        {

            XmlSerializer xml = new XmlSerializer(typeof(Spritesheet));
            try
            {
                using (StreamWriter writer = new StreamWriter(MySpriteSheets.OutputFile))
                {
                    xml.Serialize(writer, MySpriteSheets);                     
                }
            }
            catch (Exception)
            {
            }
        }
    

        private void MenuSaveAs(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == true)
            {
                tbOutputDir.Text = saveFile.FileName;
                MySpriteSheets.OutputFile = saveFile.FileName;
            }
            MenuSave(sender, e);
        }

        private void MenuExit(object sender, RoutedEventArgs e)
        {

        }
    }
}
