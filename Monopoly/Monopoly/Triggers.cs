using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Triggers
    {

        public Random myRandom = new Random();
        int myValue;

        public void Randomize()
        {
            myValue = myRandom.Next(0, 22);
        }

        public List<Tile> myTriggerList = new List<Tile>();

        public void MoveToTile(Player player,Tile currentTile)
        {
            foreach (Tile myTile in myTriggerList)//iterate through all the tiles in myListOfTiles
            {
                if (myValue == myTile.ID)//if the myCurrentPostion matches the TILE ID we set the position of the current tile to that Tile
                {
                    player.CurrentTile = myTile;
                    currentTile = myTile;//Set the position of the current tile to the position tile.
                    player.SetPosition(currentTile.ID);
                    //player.CurrentPosition = value;
                    
                }
            }

            
        }

    }
}
