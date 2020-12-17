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
using System.Text.RegularExpressions;
using MnBLib;

namespace FinalPorject_MB_Character_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Character currentCharacter;

        public CharacterCollection myCharacterCollection = new CharacterCollection();

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void MenuLoad(object sender, RoutedEventArgs e)
        {

        }
        private void MenuSave(object sender, RoutedEventArgs e)
        {

        }
        private void MenuSaveAs(object sender, RoutedEventArgs e)
        {

        }

        private void MenuExit(object sender, RoutedEventArgs e)
        {

        }

        private void btn_New(object sender, RoutedEventArgs e)
        {
            currentCharacter = myCharacterCollection.GenerateCharacter();
            tb_NAME.Text = currentCharacter.name;
            tb_STR.Text = currentCharacter.strength.ToString();
            tb_AGI.Text = currentCharacter.agility.ToString();
            tb_INT.Text = currentCharacter.intelligence.ToString();
            tb_CHR.Text = currentCharacter.charisma.ToString();
            tb_1HWeapons.Text = currentCharacter.one_handed_weapons.ToString();

        }

        private void btn_Remove(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Apply(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Reset(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
