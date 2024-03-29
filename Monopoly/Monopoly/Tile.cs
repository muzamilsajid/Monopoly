﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Tile
    {
        #region Tile Properties
        //***********************BEGIN PROPERTIES**********************
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

        bool ispurchaseable = false;
        public bool IsPurchaseAble
        {
            get { return ispurchaseable; }
        }

        //***********************END PROPERTIES**********************
        #endregion


        #region Functions
        //***********************BEGIN FUNCTIONS**********************
        public void setID(int tileID)
        {
            id = tileID;
        }

        public void SetTilePurchased()
        {
            purchased = true;
        }

        public void SetTileNotPurchased()
        {
            purchased = false;
        }

        public void SetOwner(Player player)
        {
            owner = player;
        }

        public void SetName(string Name)
        {
            name = Name;
        }

        public void SetPurchaseValue(int value)
        {
            purchasevalue = value;
        }

        public void SetIsPurchaseable()
        {
            ispurchaseable = true;
        }

        //***********************END FUNCTIONS**********************
        #endregion
    }
}
