using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!","N","N",",", ",", "k", "k",
           "b", "b", "v", "v", "w", "w", "z", "z"
        };
        // firstClicked points to the first Label control 
        Label firstClicked = null;
        // secondClicked points to the second Label control 
        Label secondClicked = null;
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }

        }

        private void label_click(object sender, EventArgs e)
        {
            if(timer1.Enabled==true)
            {
                return;
            }
            Label labelclicked = sender as Label;
            if(labelclicked != null)
            {
                if (labelclicked.ForeColor == Color.Black)
                    return;

              // labelclicked.ForeColor = Color.Black;
              if(firstClicked == null)
                {
                    firstClicked = labelclicked;
                    firstClicked.ForeColor = Color.Black;
                    return;

                }
                secondClicked = labelclicked;
                secondClicked.ForeColor = Color.Red;

                CheckForWinner();

                if(firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
           
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

           MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }
    }
}
