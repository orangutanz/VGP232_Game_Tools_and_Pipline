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
using WeaponLib;

namespace Assignment2c
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public WeaponCollection mWeaponCollection = new WeaponCollection();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadClicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                mWeaponCollection.Load(openFileDialog.FileName);
                WeaponListBox.ItemsSource = mWeaponCollection;
                WeaponListBox.Items.Refresh();
            }
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                mWeaponCollection.Save(saveFileDialog.FileName);
            }
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            EditWeaponWindow editWeaponWindow = new EditWeaponWindow();
            if(editWeaponWindow.ShowDialog() == true)
            {
                mWeaponCollection.Add(editWeaponWindow.weapon);
                WeaponListBox.Items.Refresh();
            }
        }

        private void EditClicked(object sender, RoutedEventArgs e)
        {
            if (WeaponListBox.SelectedIndex == -1)
            {
                return;
            }

            EditWeaponWindow editWeaponWindow = new EditWeaponWindow();
            editWeaponWindow.weapon = WeaponListBox.SelectedItem as Weapon;
            if(editWeaponWindow.ShowDialog() == true)
            {
                mWeaponCollection[WeaponListBox.SelectedIndex] = editWeaponWindow.weapon;
            }
            WeaponListBox.Items.Refresh();
        }

        private void RemoveClicked(object sender, RoutedEventArgs e)
        {
            if(WeaponListBox.SelectedIndex == -1)
            {
                return;
            }

            mWeaponCollection.RemoveAt(WeaponListBox.SelectedIndex);
            WeaponListBox.Items.Refresh();
        }

        private void SortName(object sender, RoutedEventArgs e)
        {
            mWeaponCollection.SortBy("name");
            WeaponListBox.Items.Refresh();

        }

        private void SortAttack(object sender, RoutedEventArgs e)
        {
            mWeaponCollection.SortBy("baseattack");
            WeaponListBox.Items.Refresh();

        }

        private void SortRarity(object sender, RoutedEventArgs e)
        {

            mWeaponCollection.SortBy("rarity");
            WeaponListBox.Items.Refresh();
        }

        private void SortPassive(object sender, RoutedEventArgs e)
        {
            mWeaponCollection.SortBy("passive");
            WeaponListBox.Items.Refresh();

        }

        private void SortSecondaryStat(object sender, RoutedEventArgs e)
        {
            mWeaponCollection.SortBy("secondarystat");
            WeaponListBox.Items.Refresh();
        }
    }
}
