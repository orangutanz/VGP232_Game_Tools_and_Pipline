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

            // LC: trigger the helper method to assign the data context
            set { mWeapon = value; } 
        }
        public EditWeaponWindow()
        {
            InitializeComponent();

            // LC: you just have to assign the data context to weapon in a helper method.
            // i.e. DataContext = weapon;
            // LC: doesn't update the title from Add to Edit and also the add button text also needs to be updated.

            if(weapon == null)
            {
                weapon = new Weapon();
            }
            TextName.Text = weapon.Name;

            // LC: this should be a combobox and you should use the Weapon.Type
            // LC: use the DataContext for databinding so you don't need to set this.
            // LC: this does not work because we cannot assign the weapon before the constructor, so edit doesn't work.
            // LC: if you're not using databinding, then you will need to move this into a Setup function and Setup is called after the weapon is assigned.
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
