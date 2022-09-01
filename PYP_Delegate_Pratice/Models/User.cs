using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_Delegate_Pratice.Models;

public class User
{
    private static int _id=1;
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public User(string name,string surname,string username,string email,string password)
    {

        Id = _id++;
        Name = name;
        Surname = surname;
        Username = username;
        Email = email;
        Password = password;
    }
}
