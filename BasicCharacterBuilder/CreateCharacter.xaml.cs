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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;

namespace BasicCharacterBuilder
{
    /// <summary>
    /// Interaction logic for CreateCharacter.xaml
    /// </summary>
    public partial class CreateCharacter : Window
    {
        MainWindow mw = new MainWindow();

        private CharactersTableAdapters.tblCharacterTableAdapter charTable = new CharactersTableAdapters.tblCharacterTableAdapter();
        private Characters chars = new Characters();

        string name; 
        string age;
        string gender;
        string race = ""; 
        string charClass = ""; 
        int str = 0;
        int dex = 0;
        int con = 0;
        int inte = 0;
        int wis = 0;
        int cha = 0; 

        string[] names = new string[] { "Finnley", "Morgan", "Jessie", "Skylar", "Frankie", "Quinn", "Adrian", "Parker", "Arrow", 
                                          "Arden", "Valen", "Ziv", "Xen", "Vesper", "Sparrow", "Roux", "Reef", "Owen", "Orion", 
                                          "Sloan", "River", "Haven", "Ellis", "Ari", "Oakley", "Arlo", "Aspen", "Grey", "Delta", 
                                          "Celyn", "Yoltzin", "Ray" };

        public CreateCharacter()
        {
            InitializeComponent();
        }

        void SetInfo()
        {
            Characters.tblCharacterRow row = (Characters.tblCharacterRow)chars.tblCharacter.NewRow();

            row.Name = name;
            row.Age = age;
            row.Gender = gender;
            row.Race = race;
            row.Class = charClass;
            row.Strength = str;
            row.Dexterity = dex;
            row.Constitution = con;
            row.Intelligence = inte;
            row.Wisdom = wis;
            row.Charisma = cha;

            chars.tblCharacter.AddtblCharacterRow(row);
            charTable.Update(chars);

            MessageBox.Show("Character successfully created!"); 
        }

        // Male
        private void btnRandomizeM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateM_Click(object sender, RoutedEventArgs e)
        {
            if (cmName.Text == "") MessageBox.Show("Name cannot be empty. Please try again. ");
            else if (cmName.Text.Contains((char)48) || cmName.Text.Contains((char)49) || cmName.Text.Contains((char)50) || cmName.Text.Contains((char)51) || cmName.Text.Contains((char)52) || cmName.Text.Contains((char)53) || cmName.Text.Contains((char)54) || cmName.Text.Contains((char)55) || cmName.Text.Contains((char)56) || cmName.Text.Contains((char)57)) MessageBox.Show("Name cannot contain numbers. Please try again.");
            else if (cmAge.Text != "" && !(cmAge.Text.Contains((char)48) || cmAge.Text.Contains((char)49) || cmAge.Text.Contains((char)50) || cmAge.Text.Contains((char)51) || cmAge.Text.Contains((char)52) || cmAge.Text.Contains((char)53) || cmAge.Text.Contains((char)54) || cmAge.Text.Contains((char)55) || cmAge.Text.Contains((char)56) || cmAge.Text.Contains((char)57))) MessageBox.Show("Age must be a number"); 
            else
            {
                // set properties specific to male 
                name = cmName.Text.ToString();
                if (cmAge.Text == "") age = "Unknown";
                else age = cmAge.Text.ToString();
                gender = "Male";

                if (race == "") race = "Human";
                if (charClass == "") charClass = "Classless"; 

                // enter information into database 
                SetInfo(); 
            }

        }

        private void cmRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mHuman.IsHighlighted) race = "Human";
            if (mDragonborn.IsHighlighted)
            {
                race = "Dragonborn";
                str += 2;
                cha++;
            }    
            if (mDwarf.IsHighlighted)
            {
                race = "Dwarf";
                con++; 
            }
            if (mElf.IsHighlighted)
            {
                race = "Elf";
                dex += 2; 
            }
            if (mGnome.IsHighlighted)
            {
                race = "Gnome";
                inte++; 
            }
            if (mHalfling.IsHighlighted)
            {
                race = "Halfling";
                dex += 2; 
            }
            if (mTiefling.IsHighlighted)
            {
                race = "Tiefling";
                inte++;
                cha += 2; 
            }
        }

        private void cmClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mClassless.IsHighlighted) charClass = "Classless"; 
            if (mBarbarian.IsHighlighted)
            {
                charClass = "Barbarian";
                str++; 
            }
            if (mBard.IsHighlighted)
            {
                charClass = "Bard";
                cha++; 
            }
            if (mCleric.IsHighlighted)
            {
                charClass = "Cleric";
                wis++; 
            }
            if (mDruid.IsHighlighted)
            {
                charClass = "Druid";
                wis++; 
            }
            if (mFighter.IsHighlighted)
            {
                charClass = "Fighter";
                str++;
                dex++; 
            }
            if (mMonk.IsHighlighted)
            {
                charClass = "Monk";
                dex++; 
            }
            if (mPaladin.IsHighlighted)
            {
                charClass = "Paladin";
                str++; 
            }
            if (mRanger.IsHighlighted)
            {
                charClass = "Ranger";
                dex++; 
            }
            if (mRouge.IsHighlighted)
            {
                charClass = "Rouge";
                dex++; 
            }
            if (mSorcerer.IsHighlighted)
            {
                charClass = "Sorcerer";
                cha++; 
            }
            if (mWarlock.IsHighlighted)
            {
                charClass = "Warlock";
                cha++; 
            }
            if (mWizard.IsHighlighted)
            {
                charClass = "Wizard";
                inte++; 
            }
        }

        // Female
        private void btnRandomizeF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cfRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cfClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Other
        private void btnRandomizeO_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateO_Click(object sender, RoutedEventArgs e)
        {

        }

        private void coRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void coClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
