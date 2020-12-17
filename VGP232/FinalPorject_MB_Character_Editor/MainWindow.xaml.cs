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
using System.Text.RegularExpressions;
using MnBLib;

namespace FinalPorject_MB_Character_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public sCharacter sCh;
        public Character currentCharacter;

        public CharacterCollection myCharacterCollection = new CharacterCollection();

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void MenuLoad(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if(myCharacterCollection.LoadXMLCharacter(openFileDialog.FileName))
                {
                    currentCharacter = myCharacterCollection[myCharacterCollection.Count-1];
                }
                UpdateMyPropertyValue();
            }
        }
        private void MenuSave(object sender, RoutedEventArgs e)
        {
            if (lb_CharacterList.SelectedIndex == -1)
            {
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = myCharacterCollection[lb_CharacterList.SelectedIndex].name;
            if (saveFileDialog.ShowDialog() == true)
            {
                myCharacterCollection.SaveXMLCharacter(saveFileDialog.FileName, lb_CharacterList.SelectedIndex);
            }
        }

        private void MenuExit(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Duplicate(object sender, RoutedEventArgs e)
        {
            if(lb_CharacterList.SelectedIndex == -1 || currentCharacter == null )
            {
                return;
            }
            Character newCharacter = new Character(currentCharacter);
            newCharacter.name = "_" + newCharacter.name;
            myCharacterCollection.Add(newCharacter);

            UpdateMyPropertyValue();
        }
        private void btn_New(object sender, RoutedEventArgs e)
        {
            currentCharacter = new Character();
            myCharacterCollection.Add(currentCharacter);

            lb_CharacterList.SelectedIndex = myCharacterCollection.Count - 1;

            UpdateMyPropertyValue();

        }

        private void btn_Remove(object sender, RoutedEventArgs e)
        {
            if (lb_CharacterList.SelectedIndex == -1)
            {
                return;
            }
            myCharacterCollection.RemoveAt(lb_CharacterList.SelectedIndex);
            sCh = null;
            currentCharacter = null;
            UpdateMyPropertyValue();
        }

        private void btn_Reset(object sender, RoutedEventArgs e)
        {
            if (myCharacterCollection.Count < 1 || sCh == null || currentCharacter == null)
            {
                return;
            }
            UpdateMyPropertyValue();
        }


        private void btn_Apply(object sender, RoutedEventArgs e)
        {
            if(myCharacterCollection.Count < 1 || sCh == null || currentCharacter == null)
            {
                return;
            }

            sCh.s_name = tb_NAME.Text;
            sCh.s_strength = tb_STR.Text;
            sCh.s_agility = tb_AGI.Text;
            sCh.s_intelligence = tb_INT.Text;
            sCh.s_charisma = tb_CHR.Text;
            sCh.s_ironflesh = tb_ironflesh.Text;
            sCh.s_power_strike = tb_power_strike.Text;
            sCh.s_power_throw = tb_power_throw.Text;
            sCh.s_power_draw = tb_power_draw.Text;
            sCh.s_weapon_master = tb_weapon_master.Text;
            sCh.s_shield = tb_shield.Text;
            sCh.s_athletics = tb_athletics.Text;
            sCh.s_riding = tb_riding.Text;
            sCh.s_looting = tb_looting.Text;
            sCh.s_trainer = tb_trainer.Text;
            sCh.s_tracking = tb_tracking.Text;
            sCh.s_tactics = tb_tactics.Text;
            sCh.s_path_finding = tb_path_finding.Text;
            sCh.s_spotting = tb_spotting.Text;
            sCh.s_inventory_management = tb_inventory_management.Text;
            sCh.s_wound_treatment = tb_wound_treatment.Text;
            sCh.s_surgery = tb_surgery.Text;
            sCh.s_first_aid = tb_first_aid.Text;
            sCh.s_engineer = tb_engineer.Text;
            sCh.s_persuasion = tb_persuasion.Text;
            sCh.s_prisoner_management = tb_prisoner_management.Text;
            sCh.s_leadership = tb_leadership.Text;
            sCh.s_trade = tb_trade.Text;
            sCh.s_one_handed_weapons = tb_1HWeapons.Text;
            sCh.s_two_handed_weapons = tb_2HWeapons.Text;
            sCh.s_polearms = tb_Polearms.Text;
            sCh.s_archery = tb_Archery.Text;
            sCh.s_crossbows = tb_Crossbows.Text;
            sCh.s_throwing = tb_Throwing.Text;

            if(lb_CharacterList.SelectedIndex != -1)
            {
                currentCharacter = sCh.ToCharacterClass();
                myCharacterCollection.ApplyChangesToCharacter(currentCharacter, lb_CharacterList.SelectedIndex);                
            }
            else
            {
                string old_name = currentCharacter.name;
                currentCharacter = sCh.ToCharacterClass();
                myCharacterCollection.ApplyChangesToCharacter(currentCharacter, old_name);
            }
            UpdateMyPropertyValue();
        }
        private void UpdateMyPropertyValue()
        {
            if(sCh == null)
            {
                tb_NAME.Text = string.Empty;
                tb_STR.Text = string.Empty;
                tb_AGI.Text = string.Empty;
                tb_INT.Text = string.Empty;
                tb_CHR.Text = string.Empty;

                tb_ironflesh.Text = string.Empty;
                tb_power_strike.Text = string.Empty;
                tb_power_throw.Text = string.Empty;
                tb_power_draw.Text = string.Empty;
                tb_weapon_master.Text = string.Empty;
                tb_shield.Text = string.Empty;
                tb_athletics.Text = string.Empty;
                tb_riding.Text = string.Empty;
                tb_looting.Text = string.Empty;
                tb_trainer.Text = string.Empty;
                tb_tactics.Text = string.Empty;
                tb_tracking.Text = string.Empty;
                tb_path_finding.Text = string.Empty;
                tb_spotting.Text = string.Empty;
                tb_inventory_management.Text = string.Empty;
                tb_wound_treatment.Text = string.Empty;
                tb_surgery.Text = string.Empty;
                tb_first_aid.Text = string.Empty;
                tb_engineer.Text = string.Empty;
                tb_persuasion.Text = string.Empty;
                tb_prisoner_management.Text = string.Empty;
                tb_leadership.Text = string.Empty;
                tb_trade.Text = string.Empty;

                tb_1HWeapons.Text = string.Empty;
                tb_2HWeapons.Text = string.Empty;
                tb_Polearms.Text = string.Empty;
                tb_Archery.Text = string.Empty;
                tb_Crossbows.Text = string.Empty;
                tb_Throwing.Text = string.Empty;
            }
            else
            {
                tb_NAME.Text = sCh.s_name;
                tb_STR.Text = sCh.s_strength;
                tb_AGI.Text = sCh.s_agility;
                tb_INT.Text = sCh.s_intelligence;
                tb_CHR.Text = sCh.s_charisma;

                tb_ironflesh.Text = sCh.s_ironflesh;
                tb_power_strike.Text = sCh.s_power_strike;
                tb_power_throw.Text = sCh.s_power_throw;
                tb_power_draw.Text = sCh.s_power_draw;
                tb_weapon_master.Text = sCh.s_weapon_master;
                tb_shield.Text = sCh.s_shield;
                tb_athletics.Text = sCh.s_athletics;
                tb_riding.Text = sCh.s_riding;
                tb_looting.Text = sCh.s_looting;
                tb_trainer.Text = sCh.s_trainer;
                tb_tactics.Text = sCh.s_tactics;
                tb_tracking.Text = sCh.s_tracking;
                tb_path_finding.Text = sCh.s_path_finding;
                tb_spotting.Text = sCh.s_spotting;
                tb_inventory_management.Text = sCh.s_inventory_management;
                tb_wound_treatment.Text = sCh.s_wound_treatment;
                tb_surgery.Text = sCh.s_surgery;
                tb_first_aid.Text = sCh.s_first_aid;
                tb_engineer.Text = sCh.s_engineer;
                tb_persuasion.Text = sCh.s_persuasion;
                tb_prisoner_management.Text = sCh.s_prisoner_management;
                tb_leadership.Text = sCh.s_leadership;
                tb_trade.Text = sCh.s_trade;

                tb_1HWeapons.Text = sCh.s_one_handed_weapons;
                tb_2HWeapons.Text = sCh.s_two_handed_weapons;
                tb_Polearms.Text = sCh.s_polearms;
                tb_Archery.Text = sCh.s_archery;
                tb_Crossbows.Text = sCh.s_crossbows;
                tb_Throwing.Text = sCh.s_throwing;
            }

            lb_CharacterList.ItemsSource = myCharacterCollection;
            lb_CharacterList.Items.Refresh();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_CharacterList.SelectedIndex == -1)
            {
                return;
            }
            currentCharacter = myCharacterCollection[lb_CharacterList.SelectedIndex];
            sCh = new sCharacter(currentCharacter);

            UpdateMyPropertyValue();
        }
    }

    public class sCharacter
    {

        public sCharacter(Character source)
        {
            s_name = source.name;
            s_strength = source.strength.ToString();
            s_agility = source.agility.ToString();
            s_intelligence = source.intelligence.ToString();
            s_charisma = source.charisma.ToString();
            s_trade = source.trade.ToString();
            s_leadership = source.leadership.ToString();
            s_prisoner_management = source.leadership.ToString();
            s_persuasion = source.persuasion.ToString();
            s_engineer = source.engineer.ToString();
            s_first_aid = source.first_aid.ToString();
            s_surgery = source.surgery.ToString();
            s_wound_treatment = source.wound_treatment.ToString();
            s_inventory_management = source.wound_treatment.ToString();
            s_spotting = source.spotting.ToString();
            s_path_finding = source.path_finding.ToString();
            s_tactics = source.tactics.ToString();
            s_tracking = source.tracking.ToString();
            s_trainer = source.trainer.ToString();
            s_looting = source.looting.ToString();
            s_horse_archery = source.horse_archery.ToString();
            s_riding = source.riding.ToString();
            s_athletics = source.athletics.ToString();
            s_shield = source.shield.ToString();
            s_weapon_master = source.weapon_master.ToString();
            s_power_draw = source.power_draw.ToString();
            s_power_throw = source.power_throw.ToString();
            s_power_strike = source.power_strike.ToString();
            s_ironflesh = source.ironflesh.ToString();
            
            s_one_handed_weapons = source.one_handed_weapons.ToString();
            s_two_handed_weapons = source.two_handed_weapons.ToString();
            s_polearms = source.polearms.ToString();
            s_archery = source.archery.ToString();
            s_crossbows = source.crossbows.ToString();
            s_throwing = source.throwing.ToString();
        }

        public Character ToCharacterClass()
        {            
            Character ch = new Character();
            ch.name = s_name;
            ch.strength = int.Parse(s_strength);
            ch.agility = int.Parse(s_agility);
            ch.intelligence = int.Parse(s_intelligence);
            ch.charisma = int.Parse(s_charisma);

            ch.trade = int.Parse(s_trade);
            ch.leadership = int.Parse(s_leadership);
            ch.prisoner_management = int.Parse(s_prisoner_management);
            ch.persuasion = int.Parse(s_persuasion);
            ch.engineer = int.Parse(s_engineer);
            ch.first_aid = int.Parse(s_first_aid);
            ch.surgery = int.Parse(s_surgery);
            ch.wound_treatment = int.Parse(s_wound_treatment);
            ch.inventory_management = int.Parse(s_inventory_management);
            ch.spotting = int.Parse(s_spotting);
            ch.path_finding = int.Parse(s_path_finding);
            ch.tactics = int.Parse(s_tactics);
            ch.tracking = int.Parse(s_tracking);
            ch.trainer = int.Parse(s_trainer);
            ch.looting = int.Parse(s_looting);
            ch.horse_archery = int.Parse(s_horse_archery);
            ch.riding = int.Parse(s_riding);
            ch.athletics = int.Parse(s_athletics);
            ch.shield = int.Parse(s_shield);
            ch.weapon_master = int.Parse(s_weapon_master);
            ch.power_draw = int.Parse(s_power_draw);
            ch.power_throw = int.Parse(s_power_throw);
            ch.power_strike = int.Parse(s_power_strike);
            ch.ironflesh = int.Parse(s_ironflesh);

            ch.one_handed_weapons = int.Parse(s_one_handed_weapons);
            ch.two_handed_weapons = int.Parse(s_two_handed_weapons);
            ch.polearms = int.Parse(s_polearms);
            ch.archery = int.Parse(s_archery);
            ch.crossbows = int.Parse(s_crossbows);
            ch.throwing = int.Parse(s_throwing);


            return ch;   
        }

        public string s_name { get; set; }

        public string s_strength { get; set; }
        public string s_agility { get; set; }
        public string s_intelligence { get; set; }
        public string s_charisma { get; set; }


        public string s_trade { get; set; }
        public string s_leadership { get; set; }
        public string s_prisoner_management { get; set; }
        public string s_persuasion { get; set; }
        public string s_engineer { get; set; }
        public string s_first_aid { get; set; }
        public string s_surgery { get; set; }
        public string s_wound_treatment { get; set; }
        public string s_inventory_management { get; set; }
        public string s_spotting { get; set; }
        public string s_path_finding { get; set; }
        public string s_tactics { get; set; }
        public string s_tracking { get; set; }
        public string s_trainer { get; set; }
        public string s_looting { get; set; }
        public string s_horse_archery { get; set; }
        public string s_riding { get; set; }
        public string s_athletics { get; set; }
        public string s_shield { get; set; }
        public string s_weapon_master { get; set; }
        public string s_power_draw { get; set; }
        public string s_power_throw { get; set; }
        public string s_power_strike { get; set; }
        public string s_ironflesh { get; set; }

        public string s_one_handed_weapons { get; set; }
        public string s_two_handed_weapons { get; set; }
        public string s_polearms { get; set; }
        public string s_archery { get; set; }
        public string s_crossbows { get; set; }
        public string s_throwing { get; set; }
        public string s_firearms { get; set; }
    }

}
