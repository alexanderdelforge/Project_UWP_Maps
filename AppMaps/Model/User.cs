using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace AppMaps.Model
{
    [DataContract]
    class User
    {
        [DataMember]
        private string name;
        [DataMember]
        private string firstname;
        [DataMember]
        private string mail;
        [DataMember]
        private string password;

        public User(string _name, string _firstname, string _mail, string _password)
        {
            this.name = _name;
            this.Firstname = _firstname;
            this.Mail = _mail;
            this.Password = _password;
        }

        public override string ToString()
        {
            return name + " " + Firstname + " " + Mail;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        
    }
}
