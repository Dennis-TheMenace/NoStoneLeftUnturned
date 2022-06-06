using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace External_Tool
{
    public partial class Form1 : Form
    {

        int pointsUsed;
        int AbilityCost;
        List<string> godSpirtePaths = new List<string>() { "God Sprites\\Athena.png", "God Sprites\\Freya.png", "God Sprites\\Hades.png", "God Sprites\\Thor.png", "God Sprites\\Tyr.png", "God Sprites\\Poseidon.png" };
        List<string> godsName = new List<string>() { "Athena", "Freya", "Hades", "Thor", "Tyr", "Poseidon", };

        int imageIndexControl = 0;
        public Form1()
        {
            InitializeComponent();                   
        }
        
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            //The event that controls the sprite switching from one to another if you hit pervious
            if (imageIndexControl > 0)
            {
                imageIndexControl--;
                GodSelcterPictureBox.Image = Image.FromFile(godSpirtePaths[imageIndexControl]);
            }
            else
            {
                imageIndexControl = 5;
                GodSelcterPictureBox.Image = Image.FromFile(godSpirtePaths[imageIndexControl]);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //The event that controls the sprite switching from one to another if you hit next

            if (imageIndexControl < 5)
            {
                imageIndexControl++;
                GodSelcterPictureBox.Image = Image.FromFile(godSpirtePaths[imageIndexControl]);
            }
            else
            {
                imageIndexControl = 0;
                GodSelcterPictureBox.Image = Image.FromFile(godSpirtePaths[imageIndexControl]);
            }

        }

        private void GodHealthSlider_Scroll(object sender, EventArgs e)
        {
            //This sets the label value to be the value of the god which we will pass later 
            //Also initialized the value of the slider
            HealthDisplayLabel.Text = GodHealthSlider.Value.ToString();
            pointsUsed = GodHealthSlider.Value + attackSlider.Value + AbilityCost;
            if(pointsUsed > 200)
            {
                pointsUsed = 200;
                GodHealthSlider.Enabled = false;
                GodHealthSlider.Value =0;
                GodHealthSlider.Enabled = true;
                attackSlider.Enabled = false;
                attackSlider.Value = 0;
                attackSlider.Enabled = true;
            }       
            pointsLeftLabel.Text = pointsUsed.ToString();
        }

        private void attackSlider_Scroll(object sender, EventArgs e)
        {
            //This sets the label value to be the value of the god which we will pass later 
            //Also initialized the value of the slider
            label4.Text = attackSlider.Value.ToString();
            pointsUsed = GodHealthSlider.Value + attackSlider.Value + AbilityCost;
            if (pointsUsed > 200)
            {
                pointsUsed = 200;
                attackSlider.Enabled = false;
                attackSlider.Value = 0;
                attackSlider.Enabled = true;
                GodHealthSlider.Enabled = false;
                GodHealthSlider.Value = 0;
                GodHealthSlider.Enabled = true;
            }
            pointsLeftLabel.Text = pointsUsed.ToString();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            //To finish the process and save the custom god to a file

            if (attackSlider.Value < 1 || GodHealthSlider.Value < 1 || godsNameTextbox.Text == string.Empty || AbilitySelectorComboBox.SelectedItem == null)
            {
                MessageBox.Show("You are missing data!");
            }
            else
            {
                //This will write to the following file path Source\repos\gdaps2-2191-Team-F\External Tool\External Tool\bin\Debug
                StreamWriter godWriter = new StreamWriter("CardData.txt");
                godWriter.WriteLine(godsNameTextbox.Text);
                godWriter.WriteLine(AbilitySelectorComboBox.Text);
                godWriter.WriteLine(attackSlider.Value);
                godWriter.WriteLine(GodHealthSlider.Value);
                godWriter.WriteLine(godToReplaceComboBox.Text);
                godWriter.WriteLine(godsName[imageIndexControl]);
                godWriter.Close();                
                MessageBox.Show("Your God has been saved successfully!");
                this.Close();
            }

            
        }

        //Makes sure the numbers stay updated
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = attackSlider.Value.ToString();
            HealthDisplayLabel.Text = GodHealthSlider.Value.ToString();
            pointsLeftLabel.Text = pointsUsed.ToString();
        }

        private void AbilitySelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AbilitySelectorComboBox.Text == "Taunt - 50")
            {
                AbilityCost = 50;
            }
            else if (AbilitySelectorComboBox.Text == "Heal - 20")
            {
                AbilityCost = 20;
            }
            else if (AbilitySelectorComboBox.Text == "Water - 30")
            {
                AbilityCost = 30;
            }
            else if (AbilitySelectorComboBox.Text == "Burn - 35")
            {
                AbilityCost = 35;
            }
            else if (AbilitySelectorComboBox.Text == "Lightning - 25")
            {
                AbilityCost = 25;
            }
            else if (AbilitySelectorComboBox.Text == "SelfDamage - 50")
            {
                AbilityCost = 50;
            }
            pointsUsed = GodHealthSlider.Value + attackSlider.Value + AbilityCost;
            pointsLeftLabel.Text = pointsUsed.ToString();
        }
    }
}
