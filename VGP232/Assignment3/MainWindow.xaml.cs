using Microsoft.Win32;
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
using TextureAtlasLib;

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string projectName { get; set; }
        public Spritesheet MySpriteSheets { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MySpriteSheets = new Spritesheet();
            MySpriteSheets.InputPaths = new List<String>();
            DataContext = MySpriteSheets;
            lbImages.ItemsSource = MySpriteSheets.InputPaths;
        }


        private void OpenMenu(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == true)
            {

            }    
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
        }
    }
}
