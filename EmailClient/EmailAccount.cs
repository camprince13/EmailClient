using System;
using System.Collections.Generic;
using System.Text;

namespace EmailClient
{
    class EmailAccount
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

    }//end class
}//end namespace
