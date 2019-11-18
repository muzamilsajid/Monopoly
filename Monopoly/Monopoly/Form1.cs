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
        Player CurrentPlayer;
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

            //MessageBox.Show(myCurrentTile.ID.ToString());
        }

        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            Player = new Player();

            Player.CreatePlayer(txtFirstName.Text, txtLastName.Text);

            myListOfPlayers.Add(Player);

            AddPlayersToListBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                myTile = new Tile();
                myTile.setID(i);
                myListOfTiles.Add(myTile);
            }

            myCurrentTile = myTile;
        }

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseTile();
            AddToListBoxOfAlltilesPurchased();
        }

        void AddPlayersToListBox()
        {
            listBoxPlayers.Items.Clear();
            foreach (Player players in myListOfPlayers)
            {
                listBoxPlayers.Items.Add($"{players.FirstName} {players.LastName}");
            }
        }

        public void PurchaseTile()
        {
            
                if (myCurrentTile.Purchased == false)
                {
                    myCurrentTile.SetTilePurchased();
                    myCurrentTile.SetOwner(CurrentPlayer);
                    CurrentPlayer.TilesOwned.Add(myCurrentTile);
                    MessageBox.Show($"{myCurrentTile.ID} Purchased by {CurrentPlayer.FirstName} {CurrentPlayer.LastName}");
            }
                else
                {
                    MessageBox.Show("Tile Already Purchased");
                }

            AddToListBoxOfTilesOwned();
            
        }

        void AddToListBoxOfAlltilesPurchased()
        {
            listBoxTilesPurchased.Items.Clear();

            foreach (Tile tilesinlist in myListOfTiles)
            {
                if (tilesinlist.Purchased)
                {
                    listBoxTilesPurchased.Items.Add($"{tilesinlist.Owner.FirstName} {tilesinlist.Owner.LastName}");
                    listBoxTilesPurchased.Items.Add(tilesinlist.ID);
                }
            }
        }

        void AddToListBoxOfTilesOwned()
        {

            listBoxTilesOwned.Items.Clear();

            foreach (Tile tiles in CurrentPlayer.TilesOwned)
            {
                listBoxTilesOwned.Items.Add(tiles.ID);
            }
        }

        private void ListBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Player players in myListOfPlayers)
            {
                if(players.FirstName + " " + players.LastName == listBoxPlayers.Text)
                {
                    CurrentPlayer = players;
                }
            }

            AddToListBoxOfTilesOwned();
        }
    }
}
