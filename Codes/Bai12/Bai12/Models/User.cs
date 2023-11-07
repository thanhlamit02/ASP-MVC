using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai12.Models
{
    public class User
    {
        public String username { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String email { get; set; }

        public User()
        {
        }

        public User(string username, string password, string name, string email)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.email = email;
        }
    }
}