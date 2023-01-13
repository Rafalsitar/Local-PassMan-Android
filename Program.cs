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
            Passman("0");
        }
        static void Passman(string WrongInputs)
        {
            string dir = "LocalData";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            else;
            if (File.Exists("LocalData/Lock.lc"))
            {
                Lockout();
            }
            else;
            Console.Clear();
            Console.WriteLine("Welcome to my password manager. here you don't have to worry about data leaks as everything is stored locally.");
            Console.WriteLine("Do you want to write, read or exit? (w/r/x)");
            string wr = Console.ReadLine();
            if (wr == "w")
            {
                // write a text file containing password to the user-specified username/email
                Console.Clear();
                Console.WriteLine("What is the username/email?");
                string un = Console.ReadLine();
                string untxt = un + ".txt";
                Console.Clear();
                Console.WriteLine("For which website is it?");
                string ws = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("What is the password?");
                string pw = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter another password for reading the account details (AD Password)");
                string cd = Console.ReadLine();
                string[] lines =
                {
                    "WEBSITE", ws, "PASSWORD", pw, "ADPASS", cd
                };
                Console.Clear();
                Console.WriteLine("Writing data");
                File.WriteAllLines("LocalData/" + untxt, lines);
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
                string uname = Console.ReadLine();
                string unametxt = uname + ".txt";
                string website = File.ReadLines("LocalData/" + unametxt).SkipWhile(line => !line.Contains("WEBSITE")).Skip(1).FirstOrDefault();
                string password = File.ReadLines("LocalData/" + unametxt).SkipWhile(line => !line.Contains("PASSWORD")).Skip(1).FirstOrDefault();
                string adpass = File.ReadLines("LocalData/" + unametxt).SkipWhile(line => !line.Contains("ADPASS")).Skip(1).FirstOrDefault();
                Console.Clear();
                Console.WriteLine("an AD password is required.");
                string adpassuinput = Console.ReadLine();
                if (adpass == adpassuinput)
                {
                    Console.Clear();
                    Console.WriteLine("Username: " + uname);
                    Console.WriteLine("Website: " + website);
                    Console.WriteLine("password: " + password);
                    Console.WriteLine("Type X to exit or Y to go back to menu");
                    string exitorcontinue = Console.ReadLine();
                    if (exitorcontinue == "X")
                    {
                        Console.Clear();
                        System.Environment.Exit(0);
                    }
                    else if (exitorcontinue == "Y")
                    {
                        Passman("0");
                    }
                    else
                    {
                        Passman("0");
                    }
                }
                else if (adpass != adpassuinput)
                {
                    if (WrongInputs == "0")
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong Input.");
                        Thread.Sleep(1000);
                        Passman("1");
                    }
                    else if (WrongInputs == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong Input.");
                        Thread.Sleep(1000);
                        Passman("2");
                    }
                    else if (WrongInputs == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong Input.");
                        Thread.Sleep(1000);
                        Passman("3");
                    }
                    else if (WrongInputs == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong Input.");
                        File.Create("LocalData/Lock.lc");
                        Thread.Sleep(1000);
                        Lockout();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error.");
                        Thread.Sleep(1000);
                        Passman("3");
                    }
                }
            }
            else if (wr == "x")
            {
                System.Environment.Exit(0);
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