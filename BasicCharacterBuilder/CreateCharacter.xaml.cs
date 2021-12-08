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

        Random random = new Random();
        private int randName;
        private int randAge;
        private int randRace;
        private int randClass;

        private string name;
        private string age;
        private string gender;
        private string race = "";
        private string charClass = "";
        private int str = 0;
        private int dex = 0;
        private int con = 0;
        private int inte = 0;
        private int wis = 0;
        private int cha = 0;

        string[] names = new string[] { "Finnley", "Morgan", "Jessie", "Skylar", "Frankie", "Quinn", "Adrian", "Parker", "Arrow", //9
                                          "Arden", "Valen", "Ziv", "Xen", "Vesper", "Sparrow", "Roux", "Reef", "Owen", "Orion", //10
                                          "Sloan", "River", "Haven", "Ellis", "Ari", "Oakley", "Arlo", "Aspen", "Grey", "Delta", //10
                                          "Celyn", "Yoltzin", "Ray" }; //3

        public CreateCharacter()
        {
            InitializeComponent();
        }

        void RandomCharacter()
        {
            // get random number between 0 and 31 for name 
            // that sets the name
            randName = random.Next(0, 31);
            name = names[randName];

            // get random number between 1 and 1000 
            // that sets the age 
            randAge = random.Next(1, 1000);
            age = randAge.ToString();

            // get random number between 1 and 7 for race 
            // that sets the race 
            randRace = random.Next(1, 7);
            if (randRace == 1) race = "Human";
            else if (randRace == 2)
            {
                race = "Dragonborn";
                str += 2;
                cha++;
            }
            else if (randRace == 3)
            {
                race = "Dwarf";
                con++;
            }
            else if (randRace == 4)
            {
                race = "Elf";
                dex += 2;
            }
            else if (randRace == 5)
            {
                race = "Gnome";
                inte++;
            }
            else if (randRace == 6)
            {
                race = "Halfling";
                dex += 2;
            }
            else if (randRace == 7)
            {
                race = "Tiefling";
                inte++;
                cha += 2;
            }
            else Console.WriteLine("Race not computed correctly");

            // get random number between 1 and 13 for class 
            // that sets the class 
            randClass = random.Next(1, 13);
            if (randClass == 1) charClass = "Human";
            else if (randClass == 2)
            {
                charClass = "Barbarian";
                str++;
            }
            if (randClass == 3)
            {
                charClass = "Bard";
                cha++;
            }
            if (randClass == 4)
            {
                charClass = "Cleric";
                wis++;
            }
            if (randClass == 5)
            {
                charClass = "Druid";
                wis++;
            }
            if (randClass == 6)
            {
                charClass = "Fighter";
                str++;
                dex++;
            }
            if (randClass == 7)
            {
                charClass = "Monk";
                dex++;
            }
            if (randClass == 8)
            {
                charClass = "Paladin";
                str++;
            }
            if (randClass == 9)
            {
                charClass = "Ranger";
                dex++;
            }
            if (randClass == 10)
            {
                charClass = "Rouge";
                dex++;
            }
            if (randClass == 11)
            {
                charClass = "Sorcerer";
                cha++;
            }
            if (randClass == 12)
            {
                charClass = "Warlock";
                cha++;
            }
            if (randClass == 13)
            {
                charClass = "Wizard";
                inte++;
            }

            SetInfo();
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
            mw.Show();
            this.Close();
        }

        // Male
        private void btnRandomizeM_Click(object sender, RoutedEventArgs e)
        {
            gender = "Male";
            RandomCharacter();
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
            gender = "Female";
            RandomCharacter();
        }

        private void btnCreateF_Click(object sender, RoutedEventArgs e)
        {
            if (cfName.Text == "") MessageBox.Show("Name cannot be empty. Please try again. ");
            else if (cfName.Text.Contains((char)48) || cfName.Text.Contains((char)49) || cfName.Text.Contains((char)50) || cfName.Text.Contains((char)51) || cfName.Text.Contains((char)52) || cfName.Text.Contains((char)53) || cfName.Text.Contains((char)54) || cfName.Text.Contains((char)55) || cfName.Text.Contains((char)56) || cfName.Text.Contains((char)57)) MessageBox.Show("Name cannot contain numbers. Please try again.");
            else if (cfAge.Text != "" && !(cfAge.Text.Contains((char)48) || cfAge.Text.Contains((char)49) || cfAge.Text.Contains((char)50) || cfAge.Text.Contains((char)51) || cfAge.Text.Contains((char)52) || cfAge.Text.Contains((char)53) || cfAge.Text.Contains((char)54) || cfAge.Text.Contains((char)55) || cfAge.Text.Contains((char)56) || cfAge.Text.Contains((char)57))) MessageBox.Show("Age must be a number");
            else
            {
                // set properties specific to male 
                name = cfName.Text.ToString();
                if (cfAge.Text == "") age = "Unknown";
                else age = cfAge.Text.ToString();
                gender = "Female";

                if (race == "") race = "Human";
                if (charClass == "") charClass = "Classless";

                // enter information into database 
                SetInfo();
            }
        }

        private void cfRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fHuman.IsHighlighted) race = "Human";
            if (fDragonborn.IsHighlighted)
            {
                race = "Dragonborn";
                str += 2;
                cha++;
            }
            if (fDwarf.IsHighlighted)
            {
                race = "Dwarf";
                con++;
            }
            if (fElf.IsHighlighted)
            {
                race = "Elf";
                dex += 2;
            }
            if (fGnome.IsHighlighted)
            {
                race = "Gnome";
                inte++;
            }
            if (fHalfling.IsHighlighted)
            {
                race = "Halfling";
                dex += 2;
            }
            if (fTiefling.IsHighlighted)
            {
                race = "Tiefling";
                inte++;
                cha += 2;
            }
        }

        private void cfClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fClassless.IsHighlighted) charClass = "Classless";
            if (fBarbarian.IsHighlighted)
            {
                charClass = "Barbarian";
                str++;
            }
            if (fBard.IsHighlighted)
            {
                charClass = "Bard";
                cha++;
            }
            if (fCleric.IsHighlighted)
            {
                charClass = "Cleric";
                wis++;
            }
            if (fDruid.IsHighlighted)
            {
                charClass = "Druid";
                wis++;
            }
            if (fFighter.IsHighlighted)
            {
                charClass = "Fighter";
                str++;
                dex++;
            }
            if (fMonk.IsHighlighted)
            {
                charClass = "Monk";
                dex++;
            }
            if (fPaladin.IsHighlighted)
            {
                charClass = "Paladin";
                str++;
            }
            if (fRanger.IsHighlighted)
            {
                charClass = "Ranger";
                dex++;
            }
            if (fRouge.IsHighlighted)
            {
                charClass = "Rouge";
                dex++;
            }
            if (fSorcerer.IsHighlighted)
            {
                charClass = "Sorcerer";
                cha++;
            }
            if (fWarlock.IsHighlighted)
            {
                charClass = "Warlock";
                cha++;
            }
            if (fWizard.IsHighlighted)
            {
                charClass = "Wizard";
                inte++;
            }
        }

        // Other
        private void btnRandomizeO_Click(object sender, RoutedEventArgs e)
        {
            gender = "Other";
            RandomCharacter();
        }

        private void btnCreateO_Click(object sender, RoutedEventArgs e)
        {
            if (coName.Text == "") MessageBox.Show("Name cannot be empty. Please try again. ");
            else if (coName.Text.Contains((char)48) || coName.Text.Contains((char)49) || coName.Text.Contains((char)50) || coName.Text.Contains((char)51) || coName.Text.Contains((char)52) || coName.Text.Contains((char)53) || coName.Text.Contains((char)54) || coName.Text.Contains((char)55) || coName.Text.Contains((char)56) || coName.Text.Contains((char)57)) MessageBox.Show("Name cannot contain numbers. Please try again.");
            else if (coAge.Text != "" && !(coAge.Text.Contains((char)48) || coAge.Text.Contains((char)49) || coAge.Text.Contains((char)50) || coAge.Text.Contains((char)51) || coAge.Text.Contains((char)52) || coAge.Text.Contains((char)53) || coAge.Text.Contains((char)54) || coAge.Text.Contains((char)55) || coAge.Text.Contains((char)56) || coAge.Text.Contains((char)57))) MessageBox.Show("Age must be a number");
            else
            {
                // set properties specific to male 
                name = coName.Text.ToString();
                if (coAge.Text == "") age = "Unknown";
                else age = coAge.Text.ToString();
                gender = "Other";

                if (race == "") race = "Human";
                if (charClass == "") charClass = "Classless";

                // enter information into database 
                SetInfo();
            }
        }

        private void coRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (oHuman.IsHighlighted) race = "Human";
            if (oDragonborn.IsHighlighted)
            {
                race = "Dragonborn";
                str += 2;
                cha++;
            }
            if (oDwarf.IsHighlighted)
            {
                race = "Dwarf";
                con++;
            }
            if (oElf.IsHighlighted)
            {
                race = "Elf";
                dex += 2;
            }
            if (oGnome.IsHighlighted)
            {
                race = "Gnome";
                inte++;
            }
            if (oHalfling.IsHighlighted)
            {
                race = "Halfling";
                dex += 2;
            }
            if (oTiefling.IsHighlighted)
            {
                race = "Tiefling";
                inte++;
                cha += 2;
            }
        }

        private void coClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (oClassless.IsHighlighted) charClass = "Classless";
            if (oBarbarian.IsHighlighted)
            {
                charClass = "Barbarian";
                str++;
            }
            if (oBard.IsHighlighted)
            {
                charClass = "Bard";
                cha++;
            }
            if (oCleric.IsHighlighted)
            {
                charClass = "Cleric";
                wis++;
            }
            if (oDruid.IsHighlighted)
            {
                charClass = "Druid";
                wis++;
            }
            if (oFighter.IsHighlighted)
            {
                charClass = "Fighter";
                str++;
                dex++;
            }
            if (oMonk.IsHighlighted)
            {
                charClass = "Monk";
                dex++;
            }
            if (oPaladin.IsHighlighted)
            {
                charClass = "Paladin";
                str++;
            }
            if (oRanger.IsHighlighted)
            {
                charClass = "Ranger";
                dex++;
            }
            if (oRouge.IsHighlighted)
            {
                charClass = "Rouge";
                dex++;
            }
            if (oSorcerer.IsHighlighted)
            {
                charClass = "Sorcerer";
                cha++;
            }
            if (oWarlock.IsHighlighted)
            {
                charClass = "Warlock";
                cha++;
            }
            if (oWizard.IsHighlighted)
            {
                charClass = "Wizard";
                inte++;
            }
        }
    }
}
