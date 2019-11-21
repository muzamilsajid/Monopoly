using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Player
    {

        string firstname;
        public string FirstName
        {
            get { return firstname; }
        }

        string lastname;
        public string LastName
        {
            get { return lastname; }
        }

        int money = 0;
        public int Money
        {
            get { return money; }
        }

        bool turn = false;
        public bool Turn
        {
            get { return turn; }
        }


        public List<Tile> TilesOwned = new List<Tile>();

        public void CreatePlayer(string fName, string lName)
        {
            firstname = fName;
            lastname = lName;
        }

        public void AddMoney(int value)
        {
            money += value;
        }

        public void SubtractMoney(int value)
        {
            money -= value;
        }
    }
}
