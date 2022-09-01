using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PYP_Delegate_Pratice;
using static PYP_Delegate_Pratice.UsernameCheck;

namespace PYP_Delegate_Pratice.Models;

public class Company
{
    public string Name { get; set; }

    List<User> Users { get; set; }
    public Company(string name)
    {
        Users = new List<User>();
        Name = name;
    }


    public string Register(string name, string surname, string password)
    {
       
       
      
        UsernameCheckDelegate usernameCheckDelegate = new UsernameCheckDelegate(UsernameCreate);
        var username = usernameCheckDelegate.Invoke(name, surname);
        usernameCheckDelegate += CrateEmail;
        var email=usernameCheckDelegate.Invoke(name, surname);
            var result = Users.FirstOrDefault(x => x.Username == username);
        if (result != null)
            return "We have username please change name or username";


        User user = new User(name, surname, username, email, password);
        Users.Add(user);
        return $"{user.Id} Correct";
       
       

    }
    public bool Login(string username,string password)
    {
        var result=Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        if(result != null)
            return true;

        return false;
        
    }
    public List<User> GetAll(Predicate<User> filter = null)
    {
        if (filter != null)
            return Users.Where(x => filter(x)).ToList();
        else
            return Users;
            
    }

    public User GetUser(int id)
    {
        return Users.FirstOrDefault(x => x.Id == id);
    }

}
