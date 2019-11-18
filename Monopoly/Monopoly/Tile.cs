using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Tile
    {

        Player owner;

        public Player Owner
        {
            get { return owner; }
        }
        
        int id;
        public int ID
        {
            get { return id; }
        }

        string name;
        public string Name
        {
            get { return name; }
        }

        int purchasevalue;
        public int PurchaseValue
        {
            get { return purchasevalue; }
        }

        int salesvalue;
        public int SalesValue
        {
            get { return salesvalue; }
        }

        int rent;
        public int Rent
        {
            get { return rent; }
        }

        bool purchased = false;
        public bool Purchased
        {
            get { return purchased; }
        }
        

        public void setID(int tileID)
        {
            id = tileID;
        }

        public void SetTilePurchased()
        {
            purchased = true;
        }
        
        public void SetOwner(Player player)
        {
            owner = player;
        }
    }
}
