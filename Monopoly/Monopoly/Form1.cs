using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class Form1 : Form
    {
        Tile myTile;
        Tile myCurrentTile;
        List<Tile> myListOfTiles = new List<Tile>();
        List<Player> myListOfPlayers = new List<Player>();
        int myCurrentPosition = 0;

        
        Player Player;
        public Form1()
        {
            InitializeComponent();

        }

       
        private void btnDice_Click(object sender, EventArgs e)
        {
            btnDice.Text = new Random().Next(1, 7).ToString();


            if (myCurrentPosition + Convert.ToInt32(btnDice.Text) <= 10)
            {
                myCurrentPosition = myCurrentPosition + Convert.ToInt32(btnDice.Text);
                foreach (Tile myTiles in myListOfTiles)
                {
                    if (myCurrentPosition == myTiles.ID)
                    {
                        myCurrentTile = myTiles;
                    }
                }
                myCurrentTile.setID(myCurrentPosition);
                label1.Text = myCurrentPosition.ToString();
            }
            else
            {
                myCurrentPosition = myCurrentPosition - ((10 - Convert.ToInt16(btnDice.Text)) - 1);
                foreach (Tile myTiles in myListOfTiles)
                {
                    if (myCurrentPosition == myTiles.ID)
                    {
                        myCurrentTile = myTiles;
                    }
                }
                myCurrentTile.setID(myCurrentPosition);
                label1.Text = myCurrentPosition.ToString();
            }


            listBox2.Items.Clear();
                foreach (Tile myTiles in myListOfTiles)
                {
                    listBox2.Items.Add($"{myTiles.ID} - {myTiles.Purchased}");
                }

            //MessageBox.Show(myCurrentTile.ID.ToString());
        }

        private void Tile2_DoubleClick(object sender, EventArgs e)
        {
            if(myCurrentTile.ID == 2)
            {
                if(myCurrentTile.Purchased == false)
                {
                    MessageBox.Show("Tile 1 Purchased");
                    myCurrentTile.SetTilePurchased();
                }
                else
                {
                    MessageBox.Show("Tile Already Purchased");
                }
            }
            else
            {
                MessageBox.Show("You have not landed on this tile");
            }
            listBox2.Items.Clear();
            foreach (Tile myTiles in myListOfTiles)
            {
                listBox2.Items.Add(myTiles.Purchased);
            }
        }

        private void Tile3_DoubleClick(object sender, EventArgs e)
        {
            if (myCurrentTile.ID == 3)
            {
                if (myCurrentTile.Purchased == false)
                {
                    MessageBox.Show("Tile 3 Purchased");
                    myCurrentTile.SetTilePurchased();
                }
                else
                {
                    MessageBox.Show("Tile Already Purchased");
                }
            }
            else
            {
                MessageBox.Show("You have not landed on this tile");
            }
            listBox2.Items.Clear();
            foreach (Tile myTiles in myListOfTiles)
            {
                listBox2.Items.Add(myTiles.Purchased);
            }
        }

        private void Tile1_DoubleClick(object sender, EventArgs e)
        {
            if (myCurrentTile.ID == 1)
            {
                if (myCurrentTile.Purchased == false)
                {
                    MessageBox.Show("Tile 1 Purchased");
                    myCurrentTile.SetTilePurchased();
                }
                else
                {
                    MessageBox.Show("Tile Already Purchased");
                }
            }
            else
            {
                MessageBox.Show("You have not landed on this tile");
            }
            listBox2.Items.Clear();
            foreach (Tile myTiles in myListOfTiles)
            {
                listBox2.Items.Add(myTiles.Purchased);
            }
        }

        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            Player = new Player();

            Player.CreatePlayer(txtFirstName.Text, txtLastName.Text);

            myListOfPlayers.Add(Player);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                myTile = new Tile();
                myTile.setID(i);
                myListOfTiles.Add(myTile);
            }

            foreach (Tile myTiles in myListOfTiles)
            {
                listBox1.Items.Add(myTiles.ID);
                listBox2.Items.Add(myTiles.Purchased);
            }

            myCurrentTile = myTile;
        }

        private void Tile4_Click(object sender, EventArgs e)
        {

        }

        private void Tile4_DoubleClick(object sender, EventArgs e)
        {
            if (myCurrentTile.ID == 4)
            {
                if (myCurrentTile.Purchased == false)
                {
                    MessageBox.Show("Tile 3 Purchased");
                    myCurrentTile.SetTilePurchased();
                }
                else
                {
                    MessageBox.Show("Tile Already Purchased");
                }
            }
            else
            {
                MessageBox.Show("You have not landed on this tile");
            }
            listBox2.Items.Clear();
            foreach (Tile myTiles in myListOfTiles)
            {
                listBox2.Items.Add(myTiles.Purchased);
            }
        }

        private void Tile5_DoubleClick(object sender, EventArgs e)
        {
            if (myCurrentTile.ID == 5)
            {
                if (myCurrentTile.Purchased == false)
                {
                    MessageBox.Show("Tile 4 Purchased");
                    myCurrentTile.SetTilePurchased();
                }
                else
                {
                    MessageBox.Show("Tile Already Purchased");
                }
            }
            else
            {
                MessageBox.Show("You have not landed on this tile");
            }
            listBox2.Items.Clear();
            foreach (Tile myTiles in myListOfTiles)
            {
                listBox2.Items.Add(myTiles.Purchased);
            }
        }

        private void Tile1_Click(object sender, EventArgs e)
        {

        }

        private void Tile2_Click(object sender, EventArgs e)
        {

        }
    }
}
