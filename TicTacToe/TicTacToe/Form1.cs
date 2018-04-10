using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = x's turn, false = y's turn
        int turn_count = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The object of Tic Tac Toe is to get three in a row.\n" +
                "You play on a three by three game board. \n " +
                "The first player is known as X and the second is O. \n" +
                "Players alternate placing Xs and Os on the game board until either oppent has three in a row or all nine squares are filled.", "Tic Tac Toe Rules");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            try // prevents program from trying to cast menu strip as a button
            {
                Button b = (Button)sender; //casts sender object as a button and stores it as b
                if (turn)
                {
                    b.Text = "X";
                    b.BackColor = Color.Aqua;
                }
                else
                {
                    b.Text = "O";
                    b.BackColor = Color.Coral;
                }
                turn = !turn; //switches true/false --> next person's turn
                b.Enabled = false; //disables button so you can't override someone's turn
                turn_count++;

                CheckWinner();
            }
            catch { }
            
        }

        private void CheckWinner()
        {
            //set winner to false to start
            bool winner = false;


            //check rows for winners
            if((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled)) 
                winner = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
                winner = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
                winner = true;
            
            //check columns for winners
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
                winner = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
                winner = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
                winner = true;

            //check diagonals for winners
            else if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
                winner = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!a3.Enabled))
                winner = true;

            if (winner)
            {
                disableButtons();
                string victor = "";
                if (turn)
                    victor = "O";
                else
                    victor = "X";
                MessageBox.Show(victor + " Wins!", "Yay!");
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("No more turns - It's a draw!", "Stalemate");
            }

        }//end check for winner

        private void disableButtons()
        {
            try// prevents program from trying to cast menu strip as a button
            {
                foreach (Control c in Controls) //control is a generic object that needs to be converted to a button
                {
                    Button b = (Button)c; //cast it as a button
                    b.Enabled = false; //disables all buttons on form
                }
            }
            catch { }
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
            
        }
    }
}
