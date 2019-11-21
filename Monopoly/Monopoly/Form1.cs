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
        //Declare myTile Variable to Hold a Card
        Tile myTile;
        
        // myCurrentTile Holds The Currently Active Tile
        Tile myCurrentTile;
        
        //CurrentPlayer holds the currently active player.
        Player CurrentPlayer;
        
        //List for holding all the tiles (Cards)
        List<Tile> myListOfTiles = new List<Tile>();

        //List for holding All the players
        List<Player> myListOfPlayers = new List<Player>();


        int myCurrentPosition = 0;

        //List for adding all Lables(Tiles/Cards) on Load
        List<Control> TileControls = new List<Control>();

        //list for holding virtual labels created at runtime for Card/Tile Titles
        List<Label> listOfNameLabels = new List<Label>();

        //list for holding virtual labels created at runtime for Card/Tile purchase Values
        List<Label> listOfValueLabels = new List<Label>();

        //list for holding tile names assigned from listofNameLables
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
            btnDice.Text = new Random().Next(1, 7).ToString();//Create A new random value for Dice.


            if (myCurrentPosition + Convert.ToInt32(btnDice.Text) < 22)//Check if the Current position is < the total number of tiles on the board so we go back to the first tile.
            {
                myCurrentPosition = myCurrentPosition + Convert.ToInt32(btnDice.Text);//myCurrentPostion increments by the number on the dice.
                foreach (Tile myTiles in myListOfTiles)//iterate through all the tiles in myListOfTiles
                {
                    if (myCurrentPosition == myTiles.ID)//if the myCurrentPostion matches the TILE ID we set the position of the current tile to that Tile
                    {
                        myCurrentTile = myTiles;//Set the position of the current tile to the position tile.
                    }
                }
                //myCurrentTile.setID(myCurrentPosition);//Set the currentTile id to the current position
                label1.Text = myCurrentPosition.ToString();//Label1 to 21 represnt the balck tiles on the board.
                label8.Text = "Pos " + myCurrentPosition.ToString();
                label9.Text = "ID " + myCurrentTile.ID.ToString();
            }
            else //if myCurretnPosition >= 22 then set the current position to the lower numbers
            {
                myCurrentPosition = myCurrentPosition - ((23 - Convert.ToInt16(btnDice.Text)) - 1);
                foreach (Tile myTiles in myListOfTiles)
                {
                    if (myCurrentPosition == myTiles.ID)
                    {
                        myCurrentTile = myTiles;
                    }
                }
                //myCurrentTile.setID(myCurrentPosition);
                label1.Text = myCurrentPosition.ToString();
                label8.Text = "Pos " + myCurrentPosition.ToString();
                label9.Text = "ID " + myCurrentTile.ID.ToString();
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

            if(myCurrentTile.Name =="Community Chest")
            {
                MessageBox.Show("Landed On Community Chest");
            }
        }

        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            Player = new Player();

            Player.CreatePlayer(txtFirstName.Text, txtLastName.Text);
            Player.AddMoney(1000000000);

            myListOfPlayers.Add(Player);

            AddPlayersToListBox();

            listBoxPlayers.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTileNames(); //call the function which loads Tile Names

            for (int i = 0; i < 22; i++)
            {
                myTile = new Tile();//Create a new Tile
                myTile.setID(i);//Set the Tile ID to te Current i
                myListOfTiles.Add(myTile);//Add the newly created Tile to the list of tiles
            }

            myCurrentTile = myTile;

            AddTilesToListOfTileControls();//Add all the black Labels as tiles to the list of Tile controls

            int myNo = 0; //Var told haold purchase value for the Cards/Tiles

            for (int i = 0; i < TileControls.Count; i++)
            {
                TileControls[i].Text = $"{i}";//Give a text label to each Tile/Label for clarity
                myNo = myRandom.Next(100000, 200000000); //Get a value between 100,000 and 200,000,000 to assign as purchase value
                CreateNameLabels(i, listOfTileNames[i]); //Call the function of createing a label at runtime and assiging it a name from the names in the ListofTileNames

                CreateValueLabels(i, (int)RoundToNearest(myNo)); //Create the virtual label to set the purchase value of the tile and rounding off the myNo var
            }

            for (int i = 0; i < myListOfTiles.Count; i++)
            {
                myListOfTiles[i].SetName(listOfTileNames[i]); //Assign a name to the Tile Name property form the listoftileNames;
                myListOfTiles[i].SetPurchaseValue((int)Convert.ToDouble(listOfValueLabels[i].Text.ToString())); //Assign purchase value to the tile purchase property
            }

            foreach (Tile tiles in myListOfTiles)
            {
                if ((tiles.Name != "Community Chest") && (tiles.Name != "Chance"))
                {
                    tiles.SetIsPurchaseable();
                }
            }
        }

        
        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseTile(); //Call the Purchase method
            AddToListBoxOfAlltilesPurchased(); //Add the purchased tile to the litbox to hold all purchased tiles
        }

        private void ListBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBoxPlayers_Click(object sender, EventArgs e)
        {
            foreach (Player players in myListOfPlayers)
            {
                if (players.FirstName + " " + players.LastName == listBoxPlayers.Text)
                {
                    CurrentPlayer = players; //set the current player to the selected player in the listbox
                    lblMoney.Text = CurrentPlayer.Money.ToString();
                }
            }

            AddToListBoxOfTilesOwned(); //Calls the mthod which checks all the Tiles the current player holds

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

        #region My Custom Functions
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
        void LoadTileNames() //initial names given to all tiles on load
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
            nameLabel = new Label(); //Create a new Title Virtual Label everytime this method is called

            nameLabel.Name = "TileLabel" + i; //set the Name of the virtual label
            nameLabel.Top = TileControls[i].Top; //Set the top postion of the virtual label same as the Top postion of that tile
            nameLabel.Width = TileControls[i].Width; //Set the width of the virtual label to the same width as the Tile
            nameLabel.Left = TileControls[i].Left; // set the left property position of the virtual label same as the Tile
            nameLabel.Height = 20; //Give the Virtual label a height of 20
            nameLabel.BackColor = Color.Yellow; // Give the virtual lable a yellow color
            nameLabel.Text = tName; //Set the text property of the virtual label
            nameLabel.Visible = true; //Make it visible
            nameLabel.AutoSize = false; //Set the autosize propert of the lable to false.

            this.Controls.Add(nameLabel); //Add the visrtual label to the list of controls of the form

            nameLabel.BringToFront(); // Brings the virtaul label to the top most.

            listOfNameLabels.Add(nameLabel); //Add the virtual label to the listofNameLabels
        }

        void CreateValueLabels(int i, int value)
        {
            valueLabel = new Label(); //Create a new virtual label

            valueLabel.Name = "TileLabelValue" + i; //Assign the name of the virtual label
            valueLabel.Top = TileControls[i].Top + (TileControls[i].Height-20); //Set the Top postion of the virtual label 20pxls less from the bottom of the Tile
            valueLabel.Width = TileControls[i].Width; //Set the Width of the virtual label same as the Tile
            valueLabel.Left = TileControls[i].Left; // Set the left property of the virtual labe same as that of the tile
            valueLabel.Height = 20; // Set the height porperty of the visrtual label to 20
            valueLabel.BackColor = Color.Cyan; // Give a Cyan color to the virtual label
            valueLabel.Text = value.ToString("###,###,###"); //Format the vistual label to give it commas to display the amounts properly
            valueLabel.Visible = true;
            valueLabel.AutoSize = false;

            this.Controls.Add(valueLabel); // Add the virtual label to the list of controls in the form

            valueLabel.BringToFront(); // Bring the virtual label to the top of other controls

            listOfValueLabels.Add(valueLabel); // add the virtual label to the listofValueLabels
        }

        void AddTilesToListOfTileControls() //Add all black/tiel/card labels as tiles to the Tilecontrolslist
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
            if (myCurrentTile.IsPurchaseAble)
            {
                if (myCurrentTile.Purchased == false)
                {
                    myCurrentTile.SetTilePurchased(); //Sets the purchased porpert of the tile to True
                    myCurrentTile.SetOwner(CurrentPlayer); //Sets the player who owns that property
                    CurrentPlayer.TilesOwned.Add(myCurrentTile); //Add the tile to the listoftiles in the currentplayer
                    CurrentPlayer.SubtractMoney((int)Convert.ToDouble(listOfValueLabels[myCurrentTile.ID].Text));
                    MessageBox.Show($"{listOfNameLabels[myCurrentTile.ID].Text} Purchased by {CurrentPlayer.FirstName} {CurrentPlayer.LastName} for {listOfValueLabels[myCurrentTile.ID].Text}");
                }
                else
                {
                    MessageBox.Show("Tile Already Purchased");
                }
            }

            AddToListBoxOfTilesOwned(); //Checks all the tiles owned by the current player.
            
        }

        void AddToListBoxOfAlltilesPurchased() //Add All tiles purchased to the ListBox
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

        void AddToListBoxOfTilesOwned() //Refresh the tiles owned by the current player
        {

            listBoxTilesOwned.Items.Clear();

            try
            {
                foreach (Tile tiles in CurrentPlayer.TilesOwned)
                {
                    listBoxTilesOwned.Items.Add($"{tiles.Name}");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }

            lblMoney.Text = CurrentPlayer.Money.ToString();
        }


        #endregion

        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************
        //*********************************************CUSTOM FUNCTIONS*************************************************


    }
}
