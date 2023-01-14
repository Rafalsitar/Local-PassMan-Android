using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace PassMan
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Passman("0");
        }
        static void Passman(string WrongInputs)
        {
            Console.Clear();
            string dir = "LocalData";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            else;
            if (!Directory.Exists("temporary"))
            {
                Directory.CreateDirectory("temporary");
            }
            else;
            if (File.Exists("LocalData/Lock.lc"))
            {
                Lockout();
            }
            else;
            if (File.Exists("temporary/passmanusers.txt"))
            {
                File.Delete("temporary/passmanusers.txt");
            }
            else;
            if (File.Exists("LocalData/PWpass.txt"))
            {
                Console.WriteLine("Enter your program-wide password to access this program");
                string pwpassl = File.ReadAllText("LocalData/PWpass.txt");
                string pwpassuinputl = Console.ReadLine();
                if (pwpassl == pwpassuinputl) ;
                else if (pwpassl != pwpassuinputl)
                {
                    if (WrongInputs == "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Passman("1");
                    }
                    else if (WrongInputs == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Passman("2");
                    }
                    else if (WrongInputs == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Passman("3");
                    }
                    else if (WrongInputs == "3")
                    {
                        Console.Clear();
                        File.Create("LocalData/Lock.lc");
                        Console.WriteLine("Invalid Input.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Lockout();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Passman("3");
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter a program-wide password to access this program in the future");
                string pwpass = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Confirm Password");
                string pwconfirm = Console.ReadLine();
                if (pwpass == pwconfirm)
                {
                    Console.Clear();
                    File.WriteAllText("LocalData/PWpass.txt", pwpass);
                    Passman("0");
                }
                else if (pwpass != pwconfirm)
                {
                    Console.Clear();
                    Console.WriteLine("Passwords don't match. Please try again.");
                    Thread.Sleep(1000);
                    Passman("0");
                }
            }
            Console.Clear();
            Console.WriteLine("Welcome to my password manager. here you don't have to worry about data leaks as everything is stored locally.");
            Console.WriteLine("Do you want to write, read, exit, reset the program wide password or display all usernames tied to a website? (w/r/x/rst/ds)");
            string wr = Console.ReadLine();
            if (wr == "w")
            {
                // write a text file containing password to the user-specified username/email
                Console.Clear();
                Console.WriteLine("What is the username/email?");
                string un = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("For which website is it?");
                string ws = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("What is the password?");
                string pw = Console.ReadLine();
                Console.Clear();
                string ub = un + "-";
                string uws = ub + ws;
                string ffn = uws + ".txt";
                string[] lines =
                {
                    "USERNAME", un, "WEBSITE", ws, "PASSWORD", pw
                };
                Console.Clear();
                Console.WriteLine("Writing data");
                File.WriteAllLines("LocalData/" + ffn, lines);
                Console.Clear();
                Console.WriteLine("Finished writing data!");
                Thread.Sleep(1000);
                Passman("0");
            }
            else if (wr == "r")
            {
                // read the line after the username and their password and website respectively
                Console.Clear();
                Console.WriteLine("what's the username you want to get the account details?");
                string unl = Console.ReadLine();
                Console.WriteLine("For which website is it?");
                string wsl = Console.ReadLine();
                string ubl = unl + "-";
                string uwsl = ubl + wsl;
                string ffnl = uwsl + ".txt";
                if (File.Exists("LocalData/" + ffnl))
                {
                    string website = File.ReadLines("LocalData/" + ffnl).SkipWhile(line => !line.Contains("WEBSITE")).Skip(1).FirstOrDefault();
                    string password = File.ReadLines("LocalData/" + ffnl).SkipWhile(line => !line.Contains("PASSWORD")).Skip(1).FirstOrDefault();
                    Console.Clear();
                    Console.WriteLine("type in the program-wide password again to access data");
                    string pwpassuinputr = Console.ReadLine();
                    string pwpassr = File.ReadAllText("LocalData/PWpass.txt");
                    if (pwpassr == pwpassuinputr)
                    {
                        Console.Clear();
                        Console.WriteLine("Username: " + unl);
                        Console.WriteLine("Website: " + website);
                        Console.WriteLine("Password: " + password);
                    }
                    else
                    {
                        if (WrongInputs == "0")
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Passman("1");
                        }
                        else if (WrongInputs == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Passman("2");
                        }
                        else if (WrongInputs == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Passman("3");
                        }
                        else if (WrongInputs == "3")
                        {
                            Console.Clear();
                            File.Create("LocalData/Lock.lc");
                            Console.WriteLine("Invalid Input.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Lockout();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Passman("3");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("That user/website doesn't exist.");
                    Thread.Sleep(1000);
                    Passman("0");
                }
            }
            else if (wr == "x")
            {
                System.Environment.Exit(0);
            }
            else if (wr == "rst")
            {
                Console.WriteLine("Enter a program-wide password to access this program in the future");
                string pwpassrst = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Confirm Password");
                string pwconfirmrst = Console.ReadLine();
                if (pwpassrst == pwconfirmrst)
                {
                    Console.Clear();
                    File.WriteAllText("LocalData/PWpass.txt", pwpassrst);
                    Passman("0");
                }
                else if (pwpassrst != pwconfirmrst)
                {
                    Console.Clear();
                    Console.WriteLine("Passwords don't match. Please try again.");
                    Thread.Sleep(1000);
                    Passman("0");
                }
            }
            else if (wr == "ds")
            {
                Console.Clear();
                // Define the directory path
                string directoryPath = "LocalData";

                Console.WriteLine("Which website do you want to show all usernames for?");
                // Define the string to search for
                string searchString = Console.ReadLine();

                // Define the string to stop at
                string stopString = "PASSWORD";

                // Get all text files in the directory
                string[] textFiles = Directory.GetFiles(directoryPath, "*.txt");

                // Loop through each text file
                Console.Clear();
                foreach (string textFile in textFiles)
                {
                    // Read the text file
                    string text = File.ReadAllText(textFile);
                    if (text.Contains (searchString))
                    {
                        Console.WriteLine(text);
                        File.AppendAllText("temporary/passmanusers.txt", text);
                    }
                }
                Console.WriteLine("if you can't see all users, check the installation directory/temporary/passmanusers.txt");
                Console.WriteLine("Type X to leave and delete the passmanusers file or Y to go back to menu and delete the file");
                string pu = Console.ReadLine();
                if (pu == "X")
                {
                    Console.Clear();
                    File.Delete("temporary/passmanusers.txt");
                    System.Environment.Exit(0);
                }
                else if (pu == "Y")
                {
                    Console.Clear();
                    Passman("0");
                }
                else
                {
                    Console.Clear();
                    Passman("0");
                }
            }
            else
            {
                Passman("0");
            }
        }

        static void Lockout()
        {
            Console.WriteLine("Too many attempts. you have been locked out.");
            Thread.Sleep(8000);
            throw new Exception("You're Locked out.");
        }
    }
}