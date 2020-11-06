using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeaponLib;

namespace Assignment2c
{
    /// <summary>
    /// Interaction logic for EditWeaponWindow.xaml
    /// </summary>
    public partial class EditWeaponWindow : Window
    {
        private Weapon mWeapon;

        public Weapon weapon 
        { 
            get { return mWeapon; } 
            set { mWeapon = value; } 
        }
        public EditWeaponWindow()
        {
            InitializeComponent();

            if(weapon == null)
            {
                weapon = new Weapon();
            }
            TextName.Text = weapon.Name;
            TextType.Text = weapon.GetType().ToString();
            TextImage.Text = weapon.Image;
            TextRarity.Text = weapon.Rarity.ToString();
            TextBaseAttack.Text = weapon.BaseAttack.ToString();
            TextSecondaryStat.Text = weapon.SecondaryStat;
            TextPassive.Text = weapon.Passive;
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
