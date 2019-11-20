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
        #region Declarations
        Tile myTile;
        Tile myCurrentTile;
        Player CurrentPlayer;
        List<Tile> myListOfTiles = new List<Tile>();
        List<Player> myListOfPlayers = new List<Player>();
        int myCurrentPosition = 0;

        List<Control> TileControls = new List<Control>();
        List<Label> listOfNameLabels = new List<Label>();
        List<Label> listOfValueLabels = new List<Label>();

        List<string> listOfTileNames = new List<string>();

        Label nameLabel;
        Label valueLabel;

        Player Player;

        Random myRandom = new Random();
        #endregion


        public Form1()
        {
            InitializeComponent();
        }

       
        private void btnDice_Click(object sender, EventArgs e)
        {
            btnDice.Text = new Random().Next(1, 7).ToString();


            if (myCurrentPosition + Convert.ToInt32(btnDice.Text) < 22)
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
                myCurrentPosition = myCurrentPosition - ((23 - Convert.ToInt16(btnDice.Text)) - 1);
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

            //Change Color Of Each Tile Based On Current Tile Posistion
            foreach (Control myTiles in TileControls)
            {
                if(myTiles.Text == $"{myCurrentTile.ID}")
                {
                    myTiles.BackColor = Color.Red;

                    //Set Position of Player Based on Tile Position
                    btnPlayer.Left = myTiles.Left;
                    btnPlayer.Top = myTiles.Top;
                }
                else
                {
                    myTiles.BackColor = Color.Black;
                }
            }
        }

        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            Player = new Player();

            Player.CreatePlayer(txtFirstName.Text, txtLastName.Text);

            myListOfPlayers.Add(Player);

            AddPlayersToListBox();

            listBoxPlayers.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTileNames();

            for (int i = 1; i < 21; i++)
            {
                myTile = new Tile();
                myTile.setID(i);
                myListOfTiles.Add(myTile);
            }

            myCurrentTile = myTile;

            AddTilesToListOfTileControls();

            int myNo = 0;

            for (int i = 0; i < TileControls.Count; i++)
            {
                TileControls[i].Text = $"{i}";
                myNo = myRandom.Next(100000, 200000000);
                CreateNameLabels(i,listOfTileNames[i]);
                CreateValueLabels(i,(int)RoundToNearest(myNo));
            }

            for (int i = 0; i < myListOfTiles.Count; i++)
            {
                myListOfTiles[i].SetName(listOfTileNames[i + 1]);
                myListOfTiles[i].SetPurchaseValue((int)Convert.ToDouble(listOfValueLabels[i + 1].Text.ToString()));
            }
        }

        
        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseTile();
            AddToListBoxOfAlltilesPurchased();
        }

        private void ListBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Player players in myListOfPlayers)
            {
                if (players.FirstName + " " + players.LastName == listBoxPlayers.Text)
                {
                    CurrentPlayer = players;
                }
            }

            AddToListBoxOfTilesOwned();

            btnDice.Enabled = true;
            btnPurchase.Enabled = true;
        }


        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************


        double RoundToNearest(int value)
        {
            if (value >= 100000 && value <= 999999)
            {
                return Math.Round((double)value / 100000, 0) * 100000;
            }
            else if(value >= 1000000 && value <= 9999999)
            {
                return Math.Round((double)value / 1000000, 0) * 1000000;
            }
            else if(value >= 10000000 && value <= 99999999)
            {
                return Math.Round((double)value / 10000000, 0) * 10000000;
            }
            else
            {
                return Math.Round((double)value / 100000000, 0) * 100000000;
            }
        }
        void LoadTileNames()
        {
            listOfTileNames.Add("Serengeti");
            listOfTileNames.Add("Harrys");
            listOfTileNames.Add("Aim Steel 1");
            listOfTileNames.Add("Aim Steel 2");
            listOfTileNames.Add("Steel Centre 1");
            listOfTileNames.Add("Steel Centre 2");
            listOfTileNames.Add("Sameer Parts Ltd");
            listOfTileNames.Add("Hajees Bus");
            listOfTileNames.Add("BANK M");
            listOfTileNames.Add("Community Chest");
            listOfTileNames.Add("Chance");
            listOfTileNames.Add("Hot Plate");
            listOfTileNames.Add("Kipara Engineering");
            listOfTileNames.Add("Impala");
            listOfTileNames.Add("Leopard Tours");
            listOfTileNames.Add("NBC");
            listOfTileNames.Add("Sea House");
            listOfTileNames.Add("NHC 1");
            listOfTileNames.Add("NHC 2");
            listOfTileNames.Add("NHC 3");
            listOfTileNames.Add("NHC 4");
            listOfTileNames.Add("NHC 5");
        }
        void CreateNameLabels(int i,string tName)
        {
            nameLabel = new Label();

            nameLabel.Name = "TileLabel" + i;
            nameLabel.Top = TileControls[i].Top;
            nameLabel.Width = TileControls[i].Width;
            nameLabel.Left = TileControls[i].Left;
            nameLabel.Height = 20;
            nameLabel.BackColor = Color.Yellow;
            nameLabel.Text = tName;
            nameLabel.Visible = true;
            nameLabel.AutoSize = false;

            this.Controls.Add(nameLabel);

            nameLabel.BringToFront();

            listOfNameLabels.Add(nameLabel);
        }

        void CreateValueLabels(int i, int value)
        {
            valueLabel = new Label();

            valueLabel.Name = "TileLabelValue" + i;
            valueLabel.Top = TileControls[i].Top + (TileControls[i].Height-20);
            valueLabel.Width = TileControls[i].Width;
            valueLabel.Left = TileControls[i].Left;
            valueLabel.Height = 20;
            valueLabel.BackColor = Color.Cyan;
            valueLabel.Text = value.ToString("###,###,###");
            valueLabel.Visible = true;
            valueLabel.AutoSize = false;

            this.Controls.Add(valueLabel);

            valueLabel.BringToFront();

            listOfValueLabels.Add(valueLabel);
        }

        void AddTilesToListOfTileControls()
        {
            TileControls.Add(Tile0);
            TileControls.Add(Tile1);
            TileControls.Add(Tile2);
            TileControls.Add(Tile3);
            TileControls.Add(Tile4);
            TileControls.Add(Tile5);
            TileControls.Add(Tile6);
            TileControls.Add(Tile7);
            TileControls.Add(Tile8);
            TileControls.Add(Tile9);
            TileControls.Add(Tile10);
            TileControls.Add(Tile11);
            TileControls.Add(Tile12);
            TileControls.Add(Tile13);
            TileControls.Add(Tile14);
            TileControls.Add(Tile15);
            TileControls.Add(Tile16);
            TileControls.Add(Tile17);
            TileControls.Add(Tile18);
            TileControls.Add(Tile19);
            TileControls.Add(Tile20);
            TileControls.Add(Tile21);
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
                    MessageBox.Show($"{listOfNameLabels[myCurrentTile.ID].Text} Purchased by {CurrentPlayer.FirstName} {CurrentPlayer.LastName} for {listOfValueLabels[myCurrentTile.ID].Text}");
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
                    listBoxTilesPurchased.Items.Add(tilesinlist.Name);
                    listBoxTilesPurchased.Items.Add($"Value: {tilesinlist.PurchaseValue.ToString("###,###,###")}");
                }
            }
        }

        void AddToListBoxOfTilesOwned()
        {

            listBoxTilesOwned.Items.Clear();

            try
            {
                foreach (Tile tiles in CurrentPlayer.TilesOwned)
                {
                    listBoxTilesOwned.Items.Add(tiles.Name);
                }
            }
            catch
            {
             
            }
            
        }

        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************

       
    }
}
