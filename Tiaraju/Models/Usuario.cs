using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Models
{
    public class Usuario
    {
        

        public Usuario()
        {
            
        }
        public Usuario(int id, string name, string username, string department, string role)
        {
            Id = id;
            Name = name;
            UserName = username;
            Department = department;
            Role = role;
            Password = "1234";
            IsActive = true;

        }
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }

        public void UpdatePassword(string username,string password)
        {
            UserName = username;
            Password = password;            
        }
     }
}
