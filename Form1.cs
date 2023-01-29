using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darts
{
    public partial class Form1 : Form
    {
        int turn = 0;
        int turnCount = 0;
        int numOfPlayers;
        int[] score;
        int multi = 1;
        
        private int getButtonValue(Button b)
        {
            return int.Parse(b.Text);
        }
        private void buttonControll(bool status) 
        { 
            bt1.Enabled = status;
            bt2.Enabled = status;
            bt3.Enabled = status;
            bt4.Enabled = status;
            bt5.Enabled = status;
            bt6.Enabled = status;
            bt7.Enabled = status;
            bt8.Enabled = status;
            bt9.Enabled = status;
            bt10.Enabled = status;
            bt11.Enabled = status;
            bt12.Enabled = status;
            bt13.Enabled = status;
            bt14.Enabled = status;
            bt15.Enabled = status;
            bt16.Enabled = status;
            bt17.Enabled = status;
            bt18.Enabled = status;
            bt19.Enabled = status;
            bt20.Enabled = status;
            bt25.Enabled = status;
            bt50.Enabled = status;
            bt2x.Enabled = status;
            bt3x.Enabled = status;
        }

        private void printScore()
        {
            string s = "Score?\n";
            for (int i = 0; i < numOfPlayers; i++)
            {
                s += $"Player{i}: {score[i]}\n";
            }
            lbOut.Text = s;
        }

        private void printPlayer()
        {
            lbPlayer.Text = $"Player {turn % numOfPlayers} is on the move\n{turnCount} dart";
        }

        private bool checkOver() 
        {
            return true;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (turnCount > 2)
            {
                turn++;
                turnCount = 0;
            }

            turnCount++;

            Button b = (Button)sender;
            int i  = getButtonValue(b);

            if (i == 25 || i == 50)
            {
                multi = 1;
                score[turn % numOfPlayers] -= i;
            }
            else
            {
                score[turn % numOfPlayers] -= i * multi;
            }

            multi = 1;
            printPlayer();
            printScore();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonControll(false);
        }
        private void buttonMulti_Click(object sender, EventArgs e)
        {
            Button d= (Button)sender;
            string t = d.Text;
            if (t == "2x")
            {
                multi = 2;
            }
            else multi = 3;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string s = tbNumOfPlayers.Text;
            string p = tbPoints.Text;

            if (!int.TryParse(s, out int num))
            {
                lbSelectionOutput.Text = "Not a num";
                return;
            }

            if (num < 1 || num > 6)
            {
                lbSelectionOutput.Text = "Wrong num";
                return;
            }

            if (!int.TryParse(p, out int point))
            {
                lbPointsOutput.Text = "Not a num";
                return;
            }

            if (point < 301)
            {
                lbPointsOutput.Text = "Wrong num";
                return;
            }

            numOfPlayers = num;
            buttonControll(true);
            btEnter.Enabled = false;
            lbSelectionOutput.Text = "Ready to play";

            score = new int[numOfPlayers];
            for (int i = 0; i < numOfPlayers; i++)
            {
                score[i] = point;
            }

            printPlayer();
            printScore();
        }
    }
}
