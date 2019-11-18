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

        public void CreatePlayer(string fName, string lName)
        {
            firstname = fName;
            lastname = lName;
        }
    }
}
