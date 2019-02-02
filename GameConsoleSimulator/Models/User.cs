using System;

namespace GameConsoleSimulator.Models
{
    public class User
    {
        public String Name { get; set; }
        public String Password { get; set; }

        public User(String Name, String Password)
        {
            this.Name = Name;
            this.Password = Password;
        }
    }
}