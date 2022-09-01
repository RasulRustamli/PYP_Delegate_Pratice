using PYP_Delegate_Pratice.Helpers;
using PYP_Delegate_Pratice.Models;
using System.Text.RegularExpressions;
using static PYP_Delegate_Pratice.UsernameCheck;

namespace PYP_Delegate_Pratice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Welcome bro");
                int result;
            Welcome:
                Console.WriteLine("Please enter Company Name");
                var companyname = Console.ReadLine();
                if (!CheckService.CheckName(companyname))
                    goto Welcome;

                Company company = new Company(companyname);
                var resultwhile = true;
                do
                {

                Switch:
                    Console.WriteLine("Please correct Choose Method");
                    Console.WriteLine("1.Create User add Company");
                    Console.WriteLine("2.Login");
                    Console.WriteLine("3.See all users");
                    Console.WriteLine("4.Get one User");
                    Console.WriteLine("5.Update User's datas");
                    Console.WriteLine("6.Delete User from Company");
                    Console.WriteLine("0.Exit");
                    Console.WriteLine("Please Select choose");
                    result = int.Parse(Console.ReadLine());

                    switch (result)
                    {
                        case 0: resultwhile = false; continue;

                        case 1:
                            CreateUser(out string name, out string surname, out string password);
                            Console.WriteLine(company.Register(name, surname, password));
                            break;

                        case 2:
                            Logın(company);
                            break;

                        case 3:
                            GetAll(company);
                            break;
                        case 4:
                            GetUser(company);
                            break;
                        case 5:
                            UpdateUser(company);
                            break;
                        case 6:
                            DeleteUser(company);
                            break;
                        default:
                            Console.WriteLine("Please correct type 0-6");
                            goto Switch;
                            break;
                    }

                } while (resultwhile);

            }
            catch (Exception)
            {

                Console.WriteLine("Please again run aplication dont enter char only number");
                
            }


            static void Logın(Company company)
            {
                Console.WriteLine("Enter username");
                var loginname = Console.ReadLine();
                Console.WriteLine("Enter password");
                var loginpasword = Console.ReadLine();
                if (company.Login(loginname, loginpasword))
                {
                    Console.WriteLine($"Welcome{loginname} ");

                }
                else
                {
                    Console.WriteLine("Error Login please again try");

                }
            }
            #region Create User
            static void CreateUser(out string name, out string surname, out string password)
            {
            Create:
                Console.WriteLine("Name enter");
                name = Console.ReadLine();

                if (!CheckService.CheckName(name))
                {
                    Console.WriteLine("Please correct name type");
                    goto Create;
                }
            Surname:
                Console.WriteLine("Surname enter");
                surname = Console.ReadLine();

                if (!CheckService.CheckName(surname))
                {
                    Console.WriteLine("Please correct surname type");
                    goto Surname;
                }
            Password:
                Console.WriteLine("Enter password");
                password = Console.ReadLine();

                if (!CheckService.PasswordCheck(password))
                {
                    Console.WriteLine("Please correct password type");
                    goto Password;

                }


            }

            #endregion
            #region GettallUser
            static void GetAll(Company company)
            {
                foreach (var item in company.GetAll())
                {
                    Console.WriteLine($" Id = {item.Id}  Username = {item.Username} Email = {item.Email}");
                }
            }
            #endregion

            #region GetUserbyId

            static void GetUser(Company company)
            {
                Console.WriteLine("Please enter User Id");
            ID:
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    var user = company.GetUser(id);
                    if (user == null)
                    {
                        Console.WriteLine("We dont have user");
                    }
                    else
                    {
                        Console.WriteLine($" Name= {user.Name}  Surname = {user.Surname} Email = {user.Email}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Id only number");
                    goto ID;
                }
            }



            #endregion

            #region UptadeUserById

            static void UpdateUser(Company company)
            {
                var result = true;

                do
                {
                    if (company.GetAll().Count() == 0)
                    {
                        Console.WriteLine("We dont have user");
                        break;
                    }

                    Console.WriteLine("Please enter User Id");
                ID:
                    int id;
                    try
                    {
                        id = int.Parse(Console.ReadLine());

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Id only number");
                        goto ID;
                    }
                    User user = company.GetUser(id);

                    if (user == null)
                    {
                        Console.WriteLine("We dont have user again correct id");

                    }

                    Console.WriteLine("Please select choose");
                    Console.WriteLine(" a. Update name");
                    Console.WriteLine(" b. Update surname");
                    Console.WriteLine("c. Update username");
                    Console.WriteLine("d. Update email");
                    string swt = Console.ReadLine().ToLower();


                    switch (swt)
                    {
                        case "a":
                            UpdateName(user, company);
                            break;
                        case "b":
                            UpdateSurname(user, company);
                            break;
                        case "c":
                            UpdateUsername(user, company);
                            break;
                        case "d":
                            UpdateEmail(user, company);
                            break;
                        default: result= false;
                            break;
                    }
                } while (result);
            }
            #region Updates methods


            static void UpdateName(User user, Company company)
            {
                Console.WriteLine($" Name = {user.Name} please enter new name");
            Result:
                var name = Console.ReadLine();
                if (!CheckService.CheckName(name))
                {
                    user.Name = name;
                }
                else
                {
                    Console.WriteLine("Please enter correc name");

                    goto Result;

                }
            }


            static void UpdateSurname(User user, Company company)
            {
                Console.WriteLine($" Name = {user.Surname} please enter new name");
            Result:
                var name = Console.ReadLine();
                if (!CheckService.CheckName(name))
                {
                    user.Surname = name;
                }
                else
                {
                    Console.WriteLine("Please enter correc name");

                    goto Result;

                }
            }


            static void UpdateUsername(User user, Company company)
            {
                Console.WriteLine($"last username = {user.Username} please enter new user name");
            AGAIN:
                var username = Console.ReadLine();
                if (username == null || username.Length <= 5)
                {
                    Console.WriteLine("please enter correct username");
                    goto AGAIN;
                }


                else
                {
                    List<User> users = company.GetAll();
                    var lastuser = users.FirstOrDefault(x => x.Username == username);
                    if (lastuser != null)
                    {
                        user.Username = username;
                    }
                    else
                    {
                        Console.WriteLine("We have this username plase change username");
                        goto AGAIN;
                    }
                }
            }


            static void UpdateEmail(User user, Company company)
            {
                Console.WriteLine($" last mail = {user.Email} please enter new mail");
            AGAIN:
                var mail = Console.ReadLine();
                if (CheckService.CheckMail(mail))
                {
                    var lastusermail = company.GetAll().FirstOrDefault(user => user.Email == mail);
                    if (lastusermail != null)
                        user.Email = mail;
                    else
                    {
                        Console.WriteLine("We have email adres please new email address");
                        goto AGAIN;
                    }
                }
                else
                {
                    Console.WriteLine("Please correct mail");
                    goto AGAIN;
                }
            }
            #endregion



            #endregion

            #region DeleteUser
            static void DeleteUser(Company company)
            {
                Console.WriteLine("Please enter User Id");
            ID:
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    var user = company.GetUser(id);
                    Console.WriteLine($"User name {user.Name} are you sure delete? y/n ");
                    var choose=Console.ReadLine().ToLower();
                    if(choose=="y")
                    {
                       var deleteuser=company.GetAll();
                        deleteuser.Remove(user);
                    }
                    else
                    {
                        Console.WriteLine("Okey I understand you");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Id only number");
                    goto ID;
                }

            }
            #endregion
        }
    }
}